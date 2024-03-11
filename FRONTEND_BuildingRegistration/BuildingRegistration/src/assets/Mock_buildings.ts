import { BuildingResponse } from "src/app/_models/Building";

export const building:BuildingResponse ={
    "buildingName": "Building Alpha",
    "buildingAddress": "Los Alamos 123",
    "buildingHasGuard": "YES",
    "buildingHasCleaningService": "YES",
    "buildingHasJanitor": "NO",
    "buildingAllowPet": "NO",
    "buildingHasWifi": "YES",
    "buildingElevatorQty": 2,
    "buildingNote": "Jkjldjfiejjelr jflsjalfkj kldjflakjdf lkjdaflk jaldkf jalf jlda \n jhdkfhskhfkshfjslfja jfljdal jjf lakj dlfj la f",
    "floorDtos": [
        {
            "floorName": "1",
            "departmentsDtos": [
                {
                    "departmentName": "A"
                },
                {
                    "departmentName": "B"
                }
            ]
        },
        {
            "floorName": "2",
            "departmentsDtos": [
                {
                    "departmentName": "A"
                },
                {
                    "departmentName": "B"
                }
            ]
        },
        {
            "floorName": "3",
            "departmentsDtos": []
        }
    ],
    "garageDtos": [
        {
            "garageLevel": "PB",
            "garageSectionsDtos": [
                {
                    "garageSectionName": "A"
                },
                {
                    "garageSectionName": "B"
                },
                {
                    "garageSectionName": "C"
                }
            ]
        },
        {
            "garageLevel": "EP",
            "garageSectionsDtos": [
                {
                    "garageSectionName": "A"
                },
                {
                    "garageSectionName": "B"
                },
                {
                    "garageSectionName": "C"
                },
                {
                    "garageSectionName": "D"
                }
            ]
        }
    ]
}

export const buildings:BuildingResponse[] = [
    {
        "buildingName": "Building Alpha",
        "buildingAddress": "Los Alamos 123",
        "buildingHasGuard": "YES",
        "buildingHasCleaningService": "YES",
        "buildingHasJanitor": "NO",
        "buildingAllowPet": "NO",
        "buildingHasWifi": "YES",
        "buildingElevatorQty": 2,
        "buildingNote": "Jkjldjfiejjelr jflsjalfkj kldjflakjdf lkjdaflk jaldkf jalf jlda \n jhdkfhskhfkshfjslfja jfljdal jjf lakj dlfj la f",
        "floorDtos": [
            {
                "floorName": "1",
                "departmentsDtos": [
                    {
                        "departmentName": "A"
                    },
                    {
                        "departmentName": "B"
                    }
                ]
            },
            {
                "floorName": "2",
                "departmentsDtos": [
                    {
                        "departmentName": "A"
                    },
                    {
                        "departmentName": "B"
                    }
                ]
            },
            {
                "floorName": "3",
                "departmentsDtos": [{"departmentName":"COMPLETE"}]
            }
        ],
        "garageDtos": [
            {
                "garageLevel": "PB",
                "garageSectionsDtos": [
                    {
                        "garageSectionName": "A"
                    },
                    {
                        "garageSectionName": "B"
                    },
                    {
                        "garageSectionName": "C"
                    }
                ]
            },
            {
                "garageLevel": "EP",
                "garageSectionsDtos": [
                    {
                        "garageSectionName": "A"
                    },
                    {
                        "garageSectionName": "B"
                    },
                    {
                        "garageSectionName": "C"
                    },
                    {
                        "garageSectionName": "D"
                    }
                ]
            }
        ]
    },

    {
        "buildingName": "Building Beta",
        "buildingAddress": "Tacuarí 23",
        "buildingHasGuard": "YES",
        "buildingHasCleaningService": "NO",
        "buildingHasJanitor": "YES",
        "buildingAllowPet": "YES",
        "buildingHasWifi": "YES",
        "buildingElevatorQty": 4,
        "buildingNote": "Jkjldjfiejjelr jflsjalfkj kldjflakjdf lkjdaflk jaldkf jalf jlda \n jhdkfhskhfkshfjslfja jfljdal jjf lakj dlfj la f",
        "floorDtos": [
            {
                "floorName": "1",
                "departmentsDtos": [
                    {
                        "departmentName": "A"
                    },
                    {
                        "departmentName": "B"
                    }
                ]
            },
            {
                "floorName": "2",
                "departmentsDtos": [
                    {
                        "departmentName": "A"
                    },
                    {
                        "departmentName": "B"
                    }
                ]
            },
            {
                "floorName": "3",
                "departmentsDtos": [{"departmentName":"COMPLETE"}]
            }
        ],
        "garageDtos": [
            {
                "garageLevel": "PB",
                "garageSectionsDtos": [
                    {
                        "garageSectionName": "A"
                    },
                    {
                        "garageSectionName": "B"
                    },
                    {
                        "garageSectionName": "C"
                    }
                ]
            },
            {
                "garageLevel": "EP",
                "garageSectionsDtos": [
                    {
                        "garageSectionName": "A"
                    },
                    {
                        "garageSectionName": "B"
                    },
                    {
                        "garageSectionName": "C"
                    },
                    {
                        "garageSectionName": "D"
                    }
                ]
            }
        ]
    },

    {
        "buildingName": "Building Echo",
        "buildingAddress": "Los Tulipanes 455",
        "buildingHasGuard": "YES",
        "buildingHasCleaningService": "YES",
        "buildingHasJanitor": "YES",
        "buildingAllowPet": "YES",
        "buildingHasWifi": "YES",
        "buildingElevatorQty": 2,
        "buildingNote": "Jkjldjfiejjelr jflsjalfkj kldjflakjdf lkjdaflk jaldkf jalf jlda \n jhdkfhskhfkshfjslfja jfljdal jjf lakj dlfj la f",
        "floorDtos": [
            {
                "floorName": "1",
                "departmentsDtos": [
                    {
                        "departmentName": "A"
                    },
                    {
                        "departmentName": "B"
                    }
                ]
            },
            {
                "floorName": "2",
                "departmentsDtos": [
                    {
                        "departmentName": "A"
                    },
                    {
                        "departmentName": "B"
                    }
                ]
            },
            {
                "floorName": "3",
                "departmentsDtos": [{"departmentName":"COMPLETE"}]
            }
        ],
        "garageDtos": [
            {
                "garageLevel": "PB",
                "garageSectionsDtos": [
                    {
                        "garageSectionName": "A"
                    },
                    {
                        "garageSectionName": "B"
                    },
                    {
                        "garageSectionName": "C"
                    }
                ]
            },
            {
                "garageLevel": "EP",
                "garageSectionsDtos": [
                    {
                        "garageSectionName": "A"
                    },
                    {
                        "garageSectionName": "B"
                    },
                    {
                        "garageSectionName": "C"
                    },
                    {
                        "garageSectionName": "D"
                    }
                ]
            }
        ]
    }
]