
# Frontend Application: Applicant Tracking System (ATS)  

This is the **Frontend** component of the **Applicant Tracking System (ATS)**, built using **Next.js**, a React-based framework for server-rendered applications. 

## Table of Contents  
1. [Project Overview](#project-overview)  
2. [Key Features](#key-features)  
3. [Technology Stack](#technology-stack)  
4. [Setup Instructions](#setup-instructions)  
    - [Prerequisites](#prerequisites)  
    - [Installation Steps](#installation-steps)  
    - [Environment Variables](#environment-variables)  
5. [Running the Application](#running-the-application)  
    - [Development Mode](#development-mode)  
    - [Production Mode](#production-mode)  
6. [Docker Integration](#docker-integration)  
    - [Building the Docker Image](#building-the-docker-image)  
    - [Running with Docker](#running-with-docker)  
7. [Testing](#testing)  
8. [Folder Structure](#folder-structure)  
9. [Future Enhancements](#future-enhancements)  

---

## Project Overview  
This Next.js application serves as the **user interface** for the ATS system, enabling HR professionals and job applicants to interact with the system. It provides functionality for user authentication, job application management and candidate tracking.  

The application communicates with the backend (written in .NET) via RESTful APIs for operations like user registration, login and data retrieval.  

---

## Key Features  
- **Responsive Design:** Fully optimized for mobile, tablet, and desktop screens.  
- **User Authentication:** Login, signup and session management with JWT tokens.  
- **Job Listings:** Browse, search and apply for jobs.  
- **Dashboard:** Admin dashboard to track applicants and manage job postings.  
- **Error Handling:** Client-side and server-side validation with friendly error messages.  
- **SEO Optimized:** Improved visibility and performance in search engines.  

---

## Technology Stack  
- **Framework:** [Next.js](https://nextjs.org/)  
- **UI Library:** [React](https://reactjs.org/)  
- **State Management:** React Context API
- **Styling:** Sass, shadcn and CSS Modules  
- **HTTP Client:** Axios and Fetch API  
- **Environment Configuration:** dotenv  
- **Version Control:** Git  

---

## Setup Instructions  

### Prerequisites  
Ensure the following are installed on your system:  
1. **Node.js** (v22.12.0)  
2. **npm** (comes with Node.js) 
3. **Docker** for containerization

### Installation Steps  
1. Clone the repository:  
   ```bash  
   git clone https://github.com/your-username/ats-frontend.git  
   cd ats-frontend  
   ```  

2. Install dependencies:  
   ```bash  
   npm install  
   ```  

### Environment Variables  
Create a `.env.local` file in the root directory and add the following environment variables:  

```bash  
NEXT_PUBLIC_API_BASE_URL=http://localhost:7113/api  # Backend API base URL  
NEXT_PUBLIC_SITE_NAME=Applicant Tracking System     # Site name  
```  

---

## Running the Application  

### Development Mode  
Start the application in development mode:  
```bash  
npm run dev  
```  
Access the application at [http://localhost:3000](http://localhost:3000).  

### Production Mode  
1. Build the application:  
   ```bash  
   npm run build  
   ```  

2. Start the production server:  
   ```bash  
   npm start  
   ```  
Access the application at [http://localhost:3000](http://localhost:3000).  

---

## Docker Integration  

### Building the Docker Image  
1. Create a `Dockerfile` in the project root:  

```dockerfile  
# Use an official Node.js runtime as a parent image  
FROM node:22  

# Set the working directory  
WORKDIR /app  

# Copy package.json and package-lock.json  
COPY package*.json ./  

# Install dependencies  
RUN npm install  

# Copy the rest of the application code  
COPY . .  

# Build the Next.js application  
RUN npm run build  

# Expose the port the app runs on  
EXPOSE 3000  

# Start the application  
CMD ["npm", "start"]  
```  

2. Build the Docker image:  
   ```bash  
   docker build -t ats-frontend .  
   ```  

### Running with Docker  
Run the application containerized:  
```bash  
docker run -p 3000:3000 ats-frontend  
```  
Access the application at [http://localhost:3000](http://localhost:3000).  

---

## Testing  
Run unit tests using Jest - configured:  
```bash  
npm test  
```  

---

## Folder Structure  

```plaintext  
ats-frontend/  
├── public/           # Static assets like images and fonts  
├── src/app 
│   ├── components/   # Reusable UI components  
│   ├── pages/        # Next.js pages  
│   ├── styles/       # Global and modular CSS files  
│   ├── utils/        # Helper functions  
│   ├── hooks/        # Custom React hooks  
│   └── services/     # API calls  
├── .env.local        # Environment variables  
├── Dockerfile        # Docker configuration  
├── next.config.js    # Next.js configuration  
├── package.json      # Project metadata and scripts  
└── README.md         # Documentation  
```  

---

## Future Enhancements   
1. **Testing:** Integrate end-to-end testing with Cypress.  
2. **Performance:** Optimize the bundle size and server-side rendering.  
3. **Analytics:** Integrate Google Analytics for tracking user behavior.
4. **Artifical Intelligence (AI):** enhancements

---

For backend setup and API documentation, please refer to the **Backend README**.