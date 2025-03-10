# RabitMqUdemy

Installing Docker and RabbitMQ
Setting Up Docker and RabbitMQ for .NET Development
In this guide, we’ll walk through the installation of Docker and RabbitMQ, which are essential tools for running microservices. Docker allows us to containerize applications, while RabbitMQ serves as a reliable message broker for communication between services.

Docker enables developers to run applications in isolated environments called containers. Let’s install Docker to support containerized .NET microservices.

Step 1: Download Docker
1. Visit the Docker Download Page

   - Go to the official Docker website.

   - Download Docker Desktop for your operating system (Windows, macOS, or Linux).

Step 2: Install Docker Desktop
1. Run the Installer

   - Open the downloaded installer file and follow the on-screen instructions.

   - On Windows, you may need to enable the “Use WSL 2 instead of Hyper-V” option if prompted.

2. Complete the Installation

   - After installation, Docker Desktop will start automatically. You may need to restart your system for the setup to complete fully.

Step 3: Verify Docker Installation
1. Open a Terminal or Command Prompt

   - Type docker --version to confirm that Docker is installed and running.

   - You should see a version number, indicating that Docker is ready for use.

Step 4 : Installing RabbitMQ
RabbitMQ is an open-source message broker used for inter-service communication in microservice architectures. We’ll use Docker to set up RabbitMQ in a container.

Step 5 : Pull the RabbitMQ Docker Image
1. Open a Terminal or Command Prompt

   - Run the following command to download the RabbitMQ image from Docker Hub:

docker pull rabbitmq:3-management
   - This image includes the RabbitMQ server and the Management Plugin, which provides a web-based interface for easier management.

Step 6: Start a RabbitMQ Container
1. Run the Container

   - Execute the following command to start RabbitMQ in a Docker container:

docker run -d --hostname rabbitmq-host --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
   - This command maps RabbitMQ’s default port (5672) and the management port (15672) to your local machine.

Step 7 : Access the RabbitMQ Management Dashboard
1. Open the Management Interface

   - Go to http://localhost:15672 in your web browser.

   - Log in with the default credentials:

Username: guest

Password: guest

2. Confirm Successful Setup

   - You should now see the RabbitMQ Management Dashboard, allowing you to monitor queues, exchanges, and messages.

Final Thoughts
Congratulations! Docker and RabbitMQ are now set up and ready for .NET microservice development. With these tools, you can create, deploy, and manage containerized services, and enable reliable communication between them through RabbitMQ.

