# Fetching the latest node image on alpine linux
FROM node:alpine AS build

# Setting up the work directory
WORKDIR /app

# Copying package.json and package-lock.json
COPY package*.json ./

# Installing dependencies
RUN npm install

# Copying the rest of the application
COPY . .

# Building the application
RUN npm run build

# Production environment
FROM nginx:stable-alpine

# Copying the build output to the Nginx directory
COPY --from=build /app/dist /usr/share/nginx/html