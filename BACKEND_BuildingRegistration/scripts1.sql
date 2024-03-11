SELECT * FROM Occupants;
SELECT * FROM Departments;

SELECT * FROM Vehicles V
INNER JOIN OccupantVehicle OV
ON V.VehicleId = OV.VehiclesVehicleId
	INNER JOIN Occupants O
	ON O.OccupantId = OV.OccupantsOccupantId;

SELECT * FROM Employees E
INNER JOIN EmployeeOccupant EO
ON E.EmployeeId = EO.EmployeesEmployeeId
	INNER JOIN Occupants O
	ON O.OccupantId = EO.OccupantsOccupantId;