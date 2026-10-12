# Uso de Inteligencia Artificial en el proyecto

## Herramientas utilizadas
- Claude (asistente de IA conversacional)
- GitHub Copilot (si lo usaste en Visual Studio; borra esta línea si no)

## Dónde se usó la IA

| Tarea | Prompt usado (resumen) | Resultado | Qué se corrigió a mano |
|---|---|---|---|
| Diseño del sistema | "Propón un proyecto en C# con POO, algo complejo" | Sistema de biblioteca con herencia y polimorfismo | Se tradujeron carpetas y clases a español |
| Pipeline de CI | "Crea un pipeline de GitHub Actions para .NET" | Archivo `ci.yml` | Falló porque la solución no estaba en la raíz; se hizo que el pipeline la busque solo |
| Documentación | "Redacta especificaciones del sistema" | `ESPECIFICACIONES.md` | Se ajustaron las reglas de negocio |
| Nueva funcionalidad | "Agrega método para listar préstamos vencidos" | `ObtenerPrestamosVencidos()` | Se movió la línea de prueba en `Program.cs` porque no se ejecutaba |

## Buenas prácticas aplicadas
1. Se revisó todo el código generado antes de subirlo.
2. Se compiló y se ejecutó el programa antes de cada commit.
3. El pipeline de CI validó cada cambio en los Pull Requests.
4. Los errores de la IA se corrigieron y quedaron en el historial (ver PR #1).

## Limitaciones encontradas
- La IA asumió una estructura de carpetas distinta a la real del repositorio.
- Algunas instrucciones dependían del idioma de Visual Studio y hubo que adaptarlas.
- El código generado no sustituye entender qué hace cada clase.

## Reflexión
La IA acelera tareas repetitivas y ayuda a aprender, pero hay que verificar
lo que genera. El pipeline y la revisión por Pull Request son la red de
seguridad que detecta cuando se equivoca.