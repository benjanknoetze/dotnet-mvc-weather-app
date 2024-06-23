# .NET MVC Weather App

A .NET MVC weather application containerized for deployment, fetching data from WeatherAPI.com.

## Features
- Fetches weather data from WeatherAPI.com
- Search with autocomplete suggestions
- Displays current weather information

## Getting Started

### Prerequisites
- Docker installed on your machine
- .NET environment

### Running the Application

1. **Pull the Docker Image**:
    ```bash
    docker pull benjan/weatherapp:latest
    ```

2. **Run the Docker Container**:
    ```bash
    docker run -d -p 8080:80 benjan/weatherapp:latest
    ```

3. **Access the Application**:
    Open your web browser and go to [http://localhost:8080](http://localhost:8080).

## Development

### Building the Docker Image

1. **Clone the Repository**:
    ```bash
    git clone https://github.com/benjanknoetze/dotnet-mvc-weather-app.git
    cd dotnet-mvc-weather-app
    ```

2. **Build the Docker Image**:
    ```bash
    docker build -t weatherapp .
    ```

3. **Run the Docker Container**:
    ```bash
    docker run -d -p 8080:80 weatherapp
    ```

### Accessing the Application for Development
- Open your web browser and go to [http://localhost:8080](http://localhost:8080).
