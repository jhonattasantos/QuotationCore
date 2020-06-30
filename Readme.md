# API documentation Quotation Core

POST create Quotation and your aggregate entities

Url: http://localhost:5000/api/quotations

```json
{
  "name": "EPI",
  "createdAt": "21/06/2020 00:00:00",
  "items": [
    {
      "code": "0000010101",
      "description": "Capacete Amarelo",
      "detailing": "Modelo XPTO",
      "quantity": 100,
      "unitOfMeasure": "UN",
      "ncm": 999222,
      "partNumber": null
    }
  ],
  "validations": [
    {
      "responseTime": "20/07/2020 00:00:00",
      "description": "Teste"
    }
  ]
}
```



GET by ID

Url: http://localhost:5000/api/quotations/4

```json
{
  "id": 4,
  "name": "EPI",
  "createdAt": "21/06/2020 00:00:00",
  "items": [
    {
      "id": 8,
      "code": "0000010101",
      "description": "Capacete Amarelo",
      "detailing": "Modelo XPTO",
      "quantity": 100,
      "unitOfMeasure": "UN",
      "ncm": 999222,
      "partNumber": null
    }
  ],
  "validations": [
    {
      "id": 1,
      "responseTime": "20/07/2020 00:00:00",
      "description": "Teste"
    }
  ]
}
```

