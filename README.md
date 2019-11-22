# TechnicalAssignment

1. Implement Repository pattern with .Net MVC
2. IoC setup (SimpleInjector with a constructor automation injection)

# Remark
* using .NET MVC
* using EntityFramework

# Get API
* GET /api/customers
    with parameter CurrencyCode for Query by Currency
    Example: /api/customers?CurrencyCode=USD

* GET /api/customers
    with parameter dateStart and dateEnd for Query by Date range ( Unix Timestamp )
    Example: /api/customers?dateStart=1574403627$dateEnd=1574403647

* GET /api/customers
    with parameter status for Query by Status
    Example: /api/customers?status=0
    
    Status mapping
        0 = A
        1 = R
        2 = D