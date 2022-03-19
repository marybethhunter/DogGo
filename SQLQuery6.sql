                        SELECT Walk.Id,
                               Walk.WalkerId,
                               Walk.[Date],
                               Walk.Duration,
                               Own.[Name]
                        FROM Walks Walk
                        LEFT JOIN Dog Dog ON Dog.Id = Walk.DogId
                        LEFT JOIN [Owner] Own ON Dog.OwnerId = Own.Id
                        WHERE WalkerId = 2;