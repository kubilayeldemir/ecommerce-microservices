FROM node:lts-alpine
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm install
COPY . .
EXPOSE 3000
ENV REDIS_URL="redis url was here"
ENV RESET_REDIS_PW="reset pw was here"
ENTRYPOINT [ "node", "index.js" ]