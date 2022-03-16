SELECT W.Id, W.Name as Name, W.ImageUrl, W.NeighborhoodId, N.Name as NName
FROM WALKER W
LEFT JOIN Neighborhood N ON N.Id = W.NeighborhoodId