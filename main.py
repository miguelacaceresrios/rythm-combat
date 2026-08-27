"""Punto de entrada del bot: elige los ejercicios del día, genera las soluciones en C#,
actualiza el README y commitea/pushea los cambios."""

from datetime import date
from pathlib import Path

from utils import content_builder as cb
from utils import git_operations as git

ROOT = Path(__file__).resolve().parent
CONFIG_PATH = ROOT / "config.json"
PROBLEMS_PATH = ROOT / "data" / "problems.json"
STATE_PATH = ROOT / "data" / "state.json"


def main() -> None:
    config = cb.load_json(CONFIG_PATH)
    problems = cb.load_json(PROBLEMS_PATH)
    state = cb.load_state(STATE_PATH)

    today = date.today().isoformat()
    if state.get("last_run") == today:
        print(f"Ya se generaron ejercicios hoy ({today}). Nada que hacer.")
        return

    distribution = config["daily_exercises"]["distribution"]
    selected = cb.select_daily_problems(problems, state, distribution)
    if not selected:
        print("No hay problemas disponibles para la distribución configurada.")
        return

    solutions_dir = ROOT / config["output"]["solutions_dir"]
    changed_files = [cb.write_solution_file(p, solutions_dir) for p in selected]

    readme_path = ROOT / config["output"]["readme_path"]
    cb.update_state(state, today, selected)
    cb.update_readme(readme_path, state)
    changed_files.append(readme_path)

    cb.save_json(STATE_PATH, state)
    changed_files.append(STATE_PATH)

    for problem in selected:
        print(f"[{problem['difficulty']}] {problem['title']} -> {cb.solution_file_path(problem, solutions_dir)}")

    git_config = config.get("git", {})
    if git_config.get("auto_commit", True):
        message = cb.build_commit_message(today, selected)
        git.commit_and_push(ROOT, changed_files, message, git_config)
    else:
        print("auto_commit deshabilitado; archivos generados pero no commiteados.")


if __name__ == "__main__":
    main()
