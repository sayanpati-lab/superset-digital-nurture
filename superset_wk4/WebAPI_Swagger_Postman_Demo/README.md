# WebAPI with Swagger and Postman Demo

This project demonstrates a basic ASP.NET Core Web API integrated with Swagger and tested using Postman.

## Features
- Swagger setup using Swashbuckle
- API testing via Postman
- Routing customization and ActionName usage

## Project Structure

```
Controllers/
├── EmployeeController.cs

Other files:
├── Program.cs
├── WebAPI_Swagger_Postman_Demo.pdf
```

## Getting Started

### Clone the Repository
```bash
git clone https://github.com/your-username/WebAPI-Swagger-Postman-Demo.git
cd WebAPI-Swagger-Postman-Demo
```

### Install NuGet Package
```
Install-Package Swashbuckle.AspNetCore
```

### Run the Application

Open Swagger UI in your browser:
```
https://localhost:<port>/swagger
```

## Postman Usage

### GET Request
```http
GET https://localhost:<port>/api/emp
```

### POST Request
```http
POST https://localhost:<port>/api/emp
Content-Type: application/json
Body: "Michael"
```

## Documentation

📘 [WebAPI_Swagger_Postman_Demo.pdf](./WebAPI_Swagger_Postman_Demo.pdf)

## Author

**John Doe**  
Email: `john@xyzmail.com`  
Website: [example.com](http://www.example.com)

## License

MIT License
