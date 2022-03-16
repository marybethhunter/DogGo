SELECT Dog.[Name] as DogName, Own.[Name] as OwnerName, Own.Id, Own.Email, Own.[Address], Own.NeighborhoodId, Own.Phone
FROM Dog Dog
LEFT JOIN Owner Own ON Own.Id = Dog.OwnerId
WHERE Own.Id = 2;

SELECT *
FROM Owner;