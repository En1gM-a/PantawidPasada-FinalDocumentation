-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: localhost    Database: pantawid_pasada
-- ------------------------------------------------------
-- Server version	8.0.45

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `admins`
--

DROP TABLE IF EXISTS `admins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admins` (
  `AdminID` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `MiddleInitial` char(1) DEFAULT NULL,
  `RoleAdmin` varchar(20) NOT NULL,
  `UsernameAdmin` varchar(50) NOT NULL,
  `PasswordAdmin` varchar(255) NOT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  `adminStatus` varchar(50) DEFAULT NULL,
  `contactNum` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  PRIMARY KEY (`AdminID`),
  UNIQUE KEY `UsernameAdmin` (`UsernameAdmin`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admins`
--

LOCK TABLES `admins` WRITE;
/*!40000 ALTER TABLE `admins` DISABLE KEYS */;
INSERT INTO `admins` VALUES (1,'Karl Adrian','Bensi','R','Admin','admin@karladrian.bensi','1234567','2026-04-17 22:15:37','Active','09123456789','karlbensi123@gmail.com'),(2,'Luke','Dongque','','Admin','admin@luke.dongque','1234567','2026-04-18 23:18:42','Deactivated','09452466578','lukedongque@gmail.com');
/*!40000 ALTER TABLE `admins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `driveraccs`
--

DROP TABLE IF EXISTS `driveraccs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `driveraccs` (
  `driver_id` int NOT NULL AUTO_INCREMENT,
  `last_name` varchar(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `address` varchar(100) NOT NULL,
  `province` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone_num` varchar(20) NOT NULL,
  `usernameUser` varchar(255) NOT NULL,
  `passwordUser` varchar(255) NOT NULL,
  `income` varchar(100) NOT NULL,
  `employment_type` varchar(100) NOT NULL,
  `source_of_income` varchar(500) NOT NULL,
  `finan_ob` varchar(500) NOT NULL,
  `lic_num` varchar(30) NOT NULL,
  `vehicle_type` varchar(50) NOT NULL,
  `plate_number` varchar(20) NOT NULL,
  `subsidy_stats` varchar(50) NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`driver_id`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `phone_num` (`phone_num`),
  UNIQUE KEY `usernameUser` (`usernameUser`),
  UNIQUE KEY `lic_num` (`lic_num`),
  UNIQUE KEY `plate_number` (`plate_number`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `driveraccs`
--

LOCK TABLES `driveraccs` WRITE;
/*!40000 ALTER TABLE `driveraccs` DISABLE KEYS */;
INSERT INTO `driveraccs` VALUES (1,'Bensi','Karl Adrian','Remulta','Babag 2, LLC','Cebu','karlbensi123@gmail.com','09513538907','karladrian.bensi','wowowin','Below 5,000','Freelance','N/A','N/A','6969','Modern Jeepney','6767','Approved','2026-04-06 14:36:47','2026-04-18 13:37:55');
/*!40000 ALTER TABLE `driveraccs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drivers`
--

DROP TABLE IF EXISTS `drivers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `drivers` (
  `driver_id` int NOT NULL AUTO_INCREMENT,
  `last_name` varchar(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) DEFAULT NULL,
  `email` varchar(100) NOT NULL,
  `phone_num` varchar(20) NOT NULL,
  `password` varchar(255) NOT NULL,
  `vehicle_type` varchar(50) DEFAULT NULL,
  `plate_number` varchar(20) DEFAULT NULL,
  `status` varchar(20) DEFAULT 'active',
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`driver_id`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `phone_num` (`phone_num`),
  UNIQUE KEY `plate_number` (`plate_number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drivers`
--

LOCK TABLES `drivers` WRITE;
/*!40000 ALTER TABLE `drivers` DISABLE KEYS */;
/*!40000 ALTER TABLE `drivers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fuelprice`
--

DROP TABLE IF EXISTS `fuelprice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fuelprice` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fuelStationName` varchar(100) NOT NULL,
  `area` varchar(100) NOT NULL,
  `dieselPrice` decimal(10,2) NOT NULL,
  `unleadedPrice` decimal(10,2) NOT NULL,
  `premiumUnleadedPrice` decimal(10,2) NOT NULL,
  `dateToday` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fuelprice`
--

LOCK TABLES `fuelprice` WRITE;
/*!40000 ALTER TABLE `fuelprice` DISABLE KEYS */;
INSERT INTO `fuelprice` VALUES (1,'Shell','Cebu City',154.20,104.60,112.50,'2026-04-14'),(2,'Petron','Cebu City',135.80,93.40,91.50,'2026-04-14'),(3,'Caltex','Cebu City',155.49,106.05,112.14,'2026-04-14'),(4,'SeaOil','Cebu City',141.10,92.70,100.00,'2026-04-14'),(5,'Shell','Lapu-Lapu City',124.90,95.10,107.10,'2026-04-18'),(6,'Petron','Cebu City',118.70,85.30,87.30,'2026-04-18'),(7,'Caltex','Mandaue City',115.60,85.41,95.40,'2026-04-18'),(8,'SeaOil','Mandaue City',114.82,83.40,83.90,'2026-04-18'),(9,'Shell','Cebu City',126.50,92.90,99.10,'2026-04-17'),(10,'Petron','Mandaue City',115.60,85.41,95.40,'2026-04-17'),(11,'Caltex','Mandaue City',127.00,95.00,101.00,'2026-04-17'),(12,'SeaOil','Lapu-Lapu City',122.21,87.27,89.27,'2026-04-17'),(13,'Shell','Lapu-Lapu City',124.90,91.11,100.14,'2026-04-19'),(14,'Petron','Talisay City',118.60,85.30,87.30,'2026-04-19'),(15,'Caltex','Cebu City',131.90,95.40,98.40,'2026-04-19'),(16,'SeaOil','Carcar City',127.51,90.27,92.27,'2026-04-19');
/*!40000 ALTER TABLE `fuelprice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fuelprices`
--

DROP TABLE IF EXISTS `fuelprices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `fuelprices` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fuelStationName` varchar(100) NOT NULL,
  `dieselPrice` decimal(10,2) NOT NULL,
  `unleadedPrice` decimal(10,2) NOT NULL,
  `premiumUnleadedPrice` decimal(10,2) NOT NULL,
  `dateToday` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fuelprices`
--

LOCK TABLES `fuelprices` WRITE;
/*!40000 ALTER TABLE `fuelprices` DISABLE KEYS */;
/*!40000 ALTER TABLE `fuelprices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `govaccs`
--

DROP TABLE IF EXISTS `govaccs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `govaccs` (
  `GovID` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(50) NOT NULL,
  `MiddleInitial` char(1) DEFAULT NULL,
  `Agency` varchar(50) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `govStatus` varchar(40) NOT NULL,
  `contactNum` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`GovID`),
  UNIQUE KEY `Username` (`Username`),
  UNIQUE KEY `contactNum` (`contactNum`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `govaccs`
--

LOCK TABLES `govaccs` WRITE;
/*!40000 ALTER TABLE `govaccs` DISABLE KEYS */;
INSERT INTO `govaccs` VALUES (1,'Karl Adrian','Bensi','R','LTFRB','gov@karladrian.bensi','wowowin','Active','09513538907','karlbensi123@gmail.com','2026-04-09 00:56:52');
/*!40000 ALTER TABLE `govaccs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-21  0:42:50
