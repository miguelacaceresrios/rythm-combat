"""Selección diaria de ejercicios y generación de archivos .cs / README."""

import json
import random
import textwrap
from pathlib import Path

README_TEMPLATE = """# 🤖 DailyCodingBot

Bot que resuelve automáticamente ejercicios de LeetCode en C# todos los días y publica \
el resultado en este repositorio. Corre gratis en GitHub Actions: sin servidores, sin \
servicios pagos.

## Cómo funciona

1. Todos los días, GitHub Actions ejecuta `main.py` mediante un cron job.
2. El bot elige ejercicios de `data/problems.json`, según la distribución de niveles \
definida en `config.json` (por defecto: 1 Easy, 1 Medium, 1 Hard), sin repetir hasta \
agotar el banco de problemas.
3. Genera un archivo `.cs` por ejercicio en `solutions/<Dificultad>/`, con el enunciado, \
la solución comentada y una breve explicación.
4. Actualiza este README y hace commit + push automáticamente.

## Configuración

Editá `config.json` para cambiar cuántos ejercicios resolver por día y cómo repartir \
los niveles de dificultad:

```json
{{
  "daily_exercises": {{
    "distribution": {{ "Easy": 1, "Medium": 1, "Hard": 1 }}
  }}
}}
```

## Estadísticas

{stats}
## Progreso diario

{table}
"""


def load_json(path: Path):
    return json.loads(path.read_text(encoding="utf-8"))


def save_json(path: Path, data) -> None:
    path.write_text(json.dumps(data, indent=2, ensure_ascii=False) + "\n", encoding="utf-8")


def load_state(path: Path) -> dict:
    if path.exists() and path.stat().st_size > 0:
        return load_json(path)
    return {"last_run": None, "used_ids": [], "total_solved": 0, "history": []}


def select_daily_problems(problems: list[dict], state: dict, distribution: dict) -> list[dict]:
    used_ids = set(state.get("used_ids", []))
    by_difficulty: dict[str, list[dict]] = {}
    for problem in problems:
        by_difficulty.setdefault(problem["difficulty"], []).append(problem)

    selected: list[dict] = []
    for difficulty, count in distribution.items():
        pool = by_difficulty.get(difficulty, [])
        if not pool or count <= 0:
            continue

        available = [p for p in pool if p["id"] not in used_ids]
        if len(available) < count:
            # Se agotó el banco para este nivel: reiniciar el ciclo.
            used_ids -= {p["id"] for p in pool}
            available = list(pool)

        chosen = random.sample(available, min(count, len(available)))
        selected.extend(chosen)
        used_ids.update(p["id"] for p in chosen)

    state["used_ids"] = sorted(used_ids)
    return selected


def update_state(state: dict, today: str, selected: list[dict]) -> None:
    state["last_run"] = today
    state["total_solved"] = state.get("total_solved", 0) + len(selected)
    history = state.setdefault("history", [])
    history.append(
        {
            "date": today,
            "problems": [
                {
                    "id": p["id"],
                    "title": p["title"],
                    "slug": p["slug"],
                    "difficulty": p["difficulty"],
                    "leetcode_url": p["leetcode_url"],
                }
                for p in selected
            ],
        }
    )


def _wrap(text: str, width: int = 96) -> list[str]:
    return textwrap.wrap(text, width=width) or [""]


def render_solution_file(problem: dict) -> str:
    lines = [f"// {problem['title']} ({problem['difficulty']})", f"// {problem['leetcode_url']}", "//"]
    for line in _wrap(problem["description"]):
        lines.append(f"// {line}")
    lines.append("//")
    lines.append("// Explicación:")
    for line in _wrap(problem["explanation"]):
        lines.append(f"// {line}")
    lines.append("")
    lines.append("using System;")
    lines.append("using System.Collections.Generic;")
    lines.append("using System.Linq;")
    lines.append("")
    lines.append(f"namespace DailyCodingBot.Solutions.{problem['difficulty']}")
    lines.append("{")
    for line in problem["solution"].splitlines():
        lines.append(f"    {line}" if line else "")
    lines.append("}")
    lines.append("")
    return "\n".join(lines)


def solution_file_path(problem: dict, solutions_dir: Path) -> Path:
    return solutions_dir / problem["difficulty"] / f"{problem['id']:03d}-{problem['slug']}.cs"


def write_solution_file(problem: dict, solutions_dir: Path) -> Path:
    file_path = solution_file_path(problem, solutions_dir)
    file_path.parent.mkdir(parents=True, exist_ok=True)
    file_path.write_text(render_solution_file(problem), encoding="utf-8")
    return file_path


def render_table(history: list[dict], limit: int = 60) -> str:
    rows = ["| Fecha | Problema | Dificultad | Solución |", "|---|---|---|---|"]
    for entry in reversed(history[-limit:]):
        for p in entry["problems"]:
            link = f"solutions/{p['difficulty']}/{p['id']:03d}-{p['slug']}.cs"
            rows.append(
                f"| {entry['date']} | [{p['title']}]({p['leetcode_url']}) | {p['difficulty']} | [{p['slug']}.cs]({link}) |"
            )
    return "\n".join(rows)


def render_readme(state: dict) -> str:
    stats = (
        f"- **Ejercicios resueltos:** {state.get('total_solved', 0)}\n"
        f"- **Días de ejecución:** {len(state.get('history', []))}\n"
        f"- **Última ejecución:** {state.get('last_run') or '—'}\n"
    )
    table = render_table(state.get("history", []))
    return README_TEMPLATE.format(stats=stats, table=table)


def update_readme(readme_path: Path, state: dict) -> None:
    readme_path.write_text(render_readme(state), encoding="utf-8")


def build_commit_message(today: str, selected: list[dict]) -> str:
    titles = ", ".join(p["title"] for p in selected)
    return f"Daily LeetCode {today}: {titles}"
