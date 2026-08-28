# 🤖 DailyCodingBot

Bot que resuelve automáticamente ejercicios de LeetCode en C# todos los días y publica el resultado en este repositorio. Corre gratis en GitHub Actions: sin servidores, sin servicios pagos.

## Cómo funciona

1. Todos los días, GitHub Actions ejecuta `main.py` mediante un cron job.
2. El bot elige ejercicios de `data/problems.json`, según la distribución de niveles definida en `config.json` (por defecto: 1 Easy, 1 Medium, 1 Hard), sin repetir hasta agotar el banco de problemas.
3. Genera un archivo `.cs` por ejercicio en `solutions/<Dificultad>/`, con el enunciado, la solución comentada y una breve explicación.
4. Actualiza este README y hace commit + push automáticamente.

## Configuración

Editá `config.json` para cambiar cuántos ejercicios resolver por día y cómo repartir los niveles de dificultad:

```json
{
  "daily_exercises": {
    "distribution": { "Easy": 1, "Medium": 1, "Hard": 1 }
  }
}
```

## Estadísticas

- **Ejercicios resueltos:** 6
- **Días de ejecución:** 2
- **Última ejecución:** 2026-08-28

## Progreso diario

| Fecha | Problema | Dificultad | Solución |
|---|---|---|---|
| 2026-08-28 | [Best Time to Buy and Sell Stock](https://leetcode.com/problems/best-time-to-buy-and-sell-stock/) | Easy | [best-time-to-buy-and-sell-stock.cs](solutions/Easy/009-best-time-to-buy-and-sell-stock.cs) |
| 2026-08-28 | [3Sum](https://leetcode.com/problems/3sum/) | Medium | [3sum.cs](solutions/Medium/013-3sum.cs) |
| 2026-08-28 | [Trapping Rain Water](https://leetcode.com/problems/trapping-rain-water/) | Hard | [trapping-rain-water.cs](solutions/Hard/021-trapping-rain-water.cs) |
| 2026-08-27 | [Remove Duplicates from Sorted Array](https://leetcode.com/problems/remove-duplicates-from-sorted-array/) | Easy | [remove-duplicates-from-sorted-array.cs](solutions/Easy/006-remove-duplicates-from-sorted-array.cs) |
| 2026-08-27 | [Add Two Numbers](https://leetcode.com/problems/add-two-numbers/) | Medium | [add-two-numbers.cs](solutions/Medium/011-add-two-numbers.cs) |
| 2026-08-27 | [Median of Two Sorted Arrays](https://leetcode.com/problems/median-of-two-sorted-arrays/) | Hard | [median-of-two-sorted-arrays.cs](solutions/Hard/019-median-of-two-sorted-arrays.cs) |
