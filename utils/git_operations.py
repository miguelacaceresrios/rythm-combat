"""Commit y push automático de los archivos generados por el bot."""

import subprocess
from pathlib import Path


class GitError(RuntimeError):
    pass


def _run(args: list[str], cwd: Path) -> str:
    result = subprocess.run(args, cwd=cwd, capture_output=True, text=True)
    if result.returncode != 0:
        raise GitError(f"`{' '.join(args)}` failed: {result.stderr.strip()}")
    return result.stdout.strip()


def is_git_repo(repo_path: Path) -> bool:
    result = subprocess.run(
        ["git", "rev-parse", "--is-inside-work-tree"],
        cwd=repo_path,
        capture_output=True,
        text=True,
    )
    return result.returncode == 0


def commit_and_push(repo_path: Path, files: list[Path], message: str, git_config: dict) -> None:
    if not is_git_repo(repo_path):
        print("Este directorio todavía no es un repositorio git; se generaron los archivos pero no se hizo commit.")
        return

    user_name = git_config.get("user_name")
    user_email = git_config.get("user_email")
    if user_name:
        _run(["git", "config", "user.name", user_name], repo_path)
    if user_email:
        _run(["git", "config", "user.email", user_email], repo_path)

    for file_path in files:
        _run(["git", "add", str(Path(file_path).relative_to(repo_path))], repo_path)

    status = _run(["git", "status", "--porcelain"], repo_path)
    if not status:
        print("No hay cambios para commitear.")
        return

    _run(["git", "commit", "-m", message], repo_path)
    print(f"Commit creado: {message}")

    if not git_config.get("auto_push", True):
        return

    remote = git_config.get("remote", "origin")
    branch = git_config.get("branch") or _run(["git", "branch", "--show-current"], repo_path)
    try:
        _run(["git", "push", remote, branch], repo_path)
        print(f"Push hecho a {remote}/{branch}.")
    except GitError as exc:
        print(f"No se pudo hacer push automáticamente: {exc}")
