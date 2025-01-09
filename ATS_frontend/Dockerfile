# Node.js image as the base image
FROM node:20

# Working directory
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install
RUN npm install --production

# Copy the rest of the application code
COPY . .

# Build the application
RUN npm run build

# Expose the port that Next.js runs on
EXPOSE 3000

# Start the application
CMD ["npm", "start"]
