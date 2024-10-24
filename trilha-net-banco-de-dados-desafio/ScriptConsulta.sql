--consulta 1
SELECT Nome,Ano FROM  dbo.Filmes 
GO
--consulta 2
SELECT Nome,Ano FROM  dbo.Filmes 
ORDER BY Ano 
GO 
--consulta 3
SELECT Nome,Ano,Duracao FROM  dbo.Filmes WHERE Nome ='Um Corpo que Cai'
GO 
--consulta 4
SELECT * FROM  dbo.Filmes WHERE Ano ='1997'
GO 
--consulta 5
SELECT * FROM  dbo.Filmes WHERE Ano >2000
GO 
--consulta 6
SELECT * FROM  dbo.Filmes WHERE Duracao >100 AND Duracao <150
ORDER BY Duracao 
GO 
--consulta 7
SELECT 
	Ano,
	COUNT(*)QuantidadeLancada
FROM Filmes
GROUP BY Ano 
ORDER BY QuantidadeLancada DESC 
GO 
--consulta 8
SELECT PrimeiroNome,UltimoNome FROM Atores WHERE Genero='M'
GO 
--consulta 9
SELECT PrimeiroNome,UltimoNome FROM Atores WHERE Genero='F' ORDER  BY Primeironome
GO 
--consulta 10
SELECT f.Nome, g.Genero AS Genero
FROM Filmes f
JOIN FilmesGenero fg ON f.Id = fg.IdFilme 
JOIN Generos g ON fg.IdGenero = g.Id

--consulta 11
SELECT f.Nome, g.Genero AS Genero
FROM Filmes f
JOIN FilmesGenero fg ON f.Id = fg.IdFilme 
JOIN Generos g ON fg.IdGenero = g.Id
WHERE g.Genero = 'Mistério';
--consulta 12
SELECT f.Nome AS NomeFilme, 
       a.PrimeiroNome, 
       a.UltimoNome, 
       fa.Papel
FROM Filmes f
JOIN ElencoFilme fa ON f.Id = fa.IdFilme 
JOIN Atores a ON fa.IdAtor = a.Id;


