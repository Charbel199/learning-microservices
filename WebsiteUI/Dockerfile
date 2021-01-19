# Stage 1
FROM node:latest as build-step
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod

# Stage 2

FROM nginx:alpine
COPY --from=build-step /app/dist/WebsiteUI /usr/share/nginx/html

