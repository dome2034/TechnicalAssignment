# TechnicalAssignment

1. Implement Repository pattern with .Net MVC
2. IoC setup (SimpleInjector with a constructor automation injection)
3. Keep log as File in Folder "ErrorLog", and separate to Debug, Error, Fatal, Verbose, Warning also.

# Remark
* using .NET MVC
* using EntityFramework

# Get API
* GET /api/transactions
    - with parameter CurrencyCode for Query by Currency
    - Example: /api/transactions?CurrencyCode=USD

* GET /api/transactions
    - with parameter dateStart and dateEnd for Query by Date range ( Unix Timestamp )
    - Example: /api/transactions?dateStart=1574403627$dateEnd=1574403647

* GET /api/transactions
    - with parameter status for Query by Status
    - Example: /api/transactions?status=0
    
    Status mapping
        0 = A, 
        1 = R, 
        2 = D