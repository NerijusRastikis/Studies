SELECT PROJEKTAS_ID, PAREIGOS, COUNT(*) as Projektai FROM DARBUOTOJAS
WHERE PAREIGOS = 'Programuotojas' OR PAREIGOS = 'Programuotoja'
GROUP BY PROJEKTAS_ID, PAREIGOS