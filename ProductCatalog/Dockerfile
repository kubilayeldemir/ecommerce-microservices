FROM maven:3.6.0-jdk-11-slim AS build
LABEL stage=builder
COPY src /src /home/app/src/
COPY pom.xml /home/app/
WORKDIR /home/app/
RUN mvn clean package

FROM openjdk:11-jre-slim
COPY --from=build home/app/target/product-category.jar app/product-category.jar
EXPOSE 8080
ENTRYPOINT ["java","-jar","app/product-category.jar"]