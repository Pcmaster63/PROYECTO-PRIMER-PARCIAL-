# Flujo de trabajo

## Estrategia de ramas
Se usa un flujo basado en ramas cortas por tarea (similar a GitHub Flow / Trunk Based):

- `master`: rama principal. Siempre debe compilar y tener el pipeline en verde.
- `feature/*`: nuevas funcionalidades (ej. `feature/listar-vencidos`).
- `docs/*`: documentación (ej. `docs/readme`).
- `ci/*`: cambios del pipeline.
- `chore/*`: mantenimiento y limpieza.
- `fix/*`: corrección de errores.

Cada rama se crea desde `master` actualizado y se elimina al hacer merge.

## Convención de commits
Formato: `tipo: descripción corta en español`

| Tipo | Uso |
|---|---|
| `feat` | Nueva funcionalidad |
| `fix` | Corrección de un error |
| `docs` | Documentación |
| `ci` | Pipeline de GitHub Actions |
| `chore` | Mantenimiento |
| `test` | Pruebas |

## Reglas de Pull Request
1. Todo cambio entra a `master` mediante Pull Request, nunca directo.
2. El título sigue la convención de commits.
3. La descripción explica qué cambia, por qué y cómo revisar.
4. El check **CI / build** debe estar en verde antes del merge.
5. Otro integrante del equipo revisa el código y deja al menos un comentario.
6. Se vincula el issue correspondiente con `Closes #N`.

## Pipeline (GitHub Actions)
En cada push y Pull Request hacia `master` se ejecuta `.github/workflows/ci.yml`:
1. Descarga el código.
2. Instala el SDK de .NET.
3. Localiza la solución.
4. Restaura dependencias.
5. Compila en modo Release.

## Gestión del proyecto
- **Issues:** una tarea por issue, con responsable.
- **Milestones:** una por semana de trabajo.
- **Projects:** tablero Kanban con las columnas To do, In progress y Done.

## Ejemplo real del proyecto
El PR #1 (`docs: agregar especificaciones del sistema`) falló la primera vez
en el pipeline porque la solución no estaba en la raíz del repositorio. Se
corrigió el `ci.yml` dentro del mismo PR, el check pasó a verde y recién
entonces se hizo el merge.