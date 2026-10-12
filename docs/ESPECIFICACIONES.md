# Especificaciones del sistema

## Requisitos funcionales
- RF1: El sistema permite registrar recursos (libros, revistas, audiolibros).
- RF2: El sistema permite registrar usuarios (estudiantes y docentes).
- RF3: El sistema permite prestar un recurso disponible a un usuario.
- RF4: El sistema calcula la fecha de vencimiento según el tipo de recurso.
- RF5: El sistema permite devolver un recurso y calcula la multa por retraso.

## Reglas de negocio
- Un estudiante puede tener máximo 3 préstamos activos; un docente, 5.
- Libro: 14 días. Revista: 7 días. Audiolibro: 10 días.
- Multa por día de retraso: libro $0.50, revista $0.25, audiolibro $0.75.
- Un recurso prestado no puede prestarse a otro usuario.

## Requisitos no funcionales
- Código orientado a objetos y organizado por capas.
- Compilación automática en cada Pull Request (GitHub Actions).
- Cambios integrados solo mediante Pull Request.