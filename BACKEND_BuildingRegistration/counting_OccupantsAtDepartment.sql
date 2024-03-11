USE BuildingRegistration;

/*
SELECT COUNT(O.OccupantName) AS OccupantsQTY FROM Departments D
INNER JOIN Occupants O
ON D.DepartmentId = O.DepartmentId
WHERE D.DepartmentId = 6;


SELECT O.OccupantName  FROM Departments D
INNER JOIN Occupants O
ON D.DepartmentId = O.DepartmentId
WHERE D.DepartmentId = 6

SELECT * FROM Occupants O
WHERE O.OccupantName = 'Martin';
*/

SELECT * FROM GarageSectionOccupant GSO
INNER JOIN GaragesSections GS
ON GSO.GarageSectionsGarageSectionId = GS.GarageSectionId
	INNER JOIN Occupants O
	ON GSO.OccupantsOccupantId = O.OccupantId;

SELECT GS.GarageSectionId, GS.GarageSectionName, O.OccupantName FROM GarageSectionOccupant GSO
INNER JOIN GaragesSections GS
ON GSO.GarageSectionsGarageSectionId = GS.GarageSectionId
	INNER JOIN Occupants O
	ON GSO.OccupantsOccupantId = O.OccupantId;

SELECT O.OccupantName FROM Occupants O
INNER JOIN GarageSectionOccupant GSO
ON O.OccupantId = GSO.OccupantsOccupantId
	INNER JOIN GaragesSections GS
	ON GSO.GarageSectionsGarageSectionId = GS.GarageSectionId
	WHERE GS.GarageSectionId = 4;