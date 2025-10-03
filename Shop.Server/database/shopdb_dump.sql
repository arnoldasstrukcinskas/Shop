-- MySQL dump 10.13  Distrib 8.1.0, for Linux (x86_64)
--
-- Host: localhost    Database: shopdb
-- ------------------------------------------------------
-- Server version	8.1.0

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
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20251001162411_Init','9.0.9');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Products`
--

DROP TABLE IF EXISTS `Products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Products` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` double NOT NULL,
  `Image` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Products`
--

LOCK TABLES `Products` WRITE;
/*!40000 ALTER TABLE `Products` DISABLE KEYS */;
INSERT INTO `Products` VALUES (1,'string',0,'string','string'),(3,'Smartphone (Flagship Model)',1099,'smartphone_flagship.jpg','Latest generation high-end smartphone with advanced camera and processor.'),(4,'Wireless Noise-Canceling Headphones',349,'headphones_nc.jpg','Over-ear headphones with industry-leading active noise cancellation.'),(5,'Smartwatch (Advanced Model)',429,'smartwatch_advanced.jpg','Fitness and health tracking smartwatch with GPS and cellular capabilities.'),(6,'Laptop (Ultrabook)',1499,'laptop_ultrabook.jpg','Thin and light laptop with premium build quality and long battery life.'),(7,'Tablet (Standard Size)',599,'tablet_standard.jpg','Versatile 11-inch tablet for entertainment and light productivity.'),(8,'Portable Bluetooth Speaker',129,'speaker_portable.jpg','Waterproof and durable speaker with powerful sound for outdoor use.'),(9,'Smart Home Hub',99,'smart_hub.jpg','Central device to control all smart home devices using voice commands.'),(10,'Robot Vacuum Cleaner',499,'robot_vacuum.jpg','Self-emptying vacuum with advanced mapping and navigation.'),(11,'True Wireless Earbuds',199,'earbuds_tws.jpg','Compact earbuds with active noise cancellation and wireless charging case.'),(12,'4K Smart TV (55-inch)',799,'tv_4k_55inch.jpg','OLED/QLED 55-inch television with high dynamic range and smart features.'),(13,'Streaming Media Player',49,'media_player_stick.jpg','Small device for streaming video content on any TV.'),(14,'External Solid State Drive (1TB)',119,'ssd_external_1tb.jpg','High-speed portable SSD for quick file transfers and backups.'),(15,'Wi-Fi Mesh System (3-Pack)',279,'wifi_mesh.jpg','Extends strong, seamless Wi-Fi coverage throughout a large home.'),(16,'Security Camera (Indoor)',69,'camera_indoor_security.jpg','Indoor security camera with 1080p video and two-way audio.'),(17,'Digital E-Reader',139,'ereader_digital.jpg','Device for reading books with a paper-like, glare-free display.'),(18,'Portable Power Bank (20000mAh)',59,'power_bank_20k.jpg','High-capacity power bank for charging multiple devices on the go.'),(19,'Gaming Console (Latest Generation)',499,'gaming_console.jpg','Next-gen gaming console with 4K support and fast loading times.'),(20,'Mechanical Keyboard',159,'keyboard_mechanical.jpg','High-quality mechanical keyboard for gaming and fast typing.'),(21,'Ergonomic Wireless Mouse',79,'mouse_wireless_ergo.jpg','Comfortable mouse designed to reduce wrist strain.'),(22,'Smart Scale (Body Composition)',89,'smart_scale.jpg','Measures weight, body fat, muscle mass, and syncs data to an app.'),(23,'Smart Video Doorbell',199,'doorbell_video_smart.jpg','Allows you to see and speak to visitors from your phone.'),(24,'Photo Printer (Instant)',99,'printer_instant_photo.jpg','Pocket-sized printer for instant photo prints from your smartphone.'),(25,'Electric Toothbrush (Sonic)',149,'toothbrush_electric_sonic.jpg','Advanced sonic electric toothbrush with multiple cleaning modes.'),(26,'Air Purifier (HEPA)',249,'air_purifier_hepa.jpg','HEPA air purifier for removing allergens and pollutants from a room.'),(27,'Smart Coffee Maker',179,'coffee_maker_smart.jpg','Wi-Fi enabled coffee maker that can be controlled remotely.'),(28,'Digital Drawing Tablet',329,'drawing_tablet_digital.jpg','Pressure-sensitive tablet for digital artists and graphic designers.'),(29,'Virtual Reality Headset',449,'vr_headset_standalone.jpg','Standalone VR headset for immersive gaming and experiences.'),(30,'Portable Monitor (15-inch)',269,'monitor_portable_15inch.jpg','Thin and light USB-C powered screen for dual-monitor setups on the go.'),(31,'Voice Recorder (Digital)',69,'recorder_voice_digital.jpg','High-quality digital voice recorder for lectures and interviews.'),(32,'Smart Water Bottle',65,'water_bottle_smart.jpg','Tracks water intake and glows to remind you to hydrate.'),(33,'Pet Camera/Treat Dispenser',149,'pet_camera_dispenser.jpg','Allows you to see, speak to, and toss treats to your pet remotely.'),(34,'Action Camera (4K)',399,'camera_action_4k.jpg','Rugged, waterproof 4K camera for capturing extreme sports.'),(35,'Home Projector (Portable)',549,'projector_home_portable.jpg','Small, high-resolution projector for movie nights anywhere.'),(36,'Wireless Charging Pad (Multi-Device)',79,'charger_wireless_multi.jpg','Pad that can simultaneously charge a phone, watch, and earbuds.'),(37,'Smart Plug (Wi-Fi)',19,'smart_plug_wifi.jpg','Allows control of non-smart appliances via an app or voice.'),(38,'Fitness Tracker (Band Style)',99,'tracker_fitness_band.jpg','Slim wristband that tracks steps, heart rate, and sleep.'),(39,'Portable Desk Fan (USB-C)',35,'fan_desk_portable.jpg','Quiet, compact fan powered by USB-C for desktop cooling.'),(40,'Security System (Starter Kit)',299,'security_system_starter.jpg','DIY home security system with sensors and a base station.'),(41,'Gaming Headset',99,'headset_gaming_wired.jpg','Comfortable over-ear headset with a clear, noise-canceling microphone.'),(42,'Smart Light Bulbs (4-Pack)',49,'smart_bulbs_rgb.jpg','Color-changing, dimmable LED bulbs controlled via an app.'),(43,'Electric Scooter (Foldable)',699,'scooter_electric_foldable.jpg','Foldable electric scooter for personal commuting.'),(44,'Car Dash Cam (Dual Channel)',159,'dash_cam_dual.jpg','Records front and rear views of your vehicle in 1080p.'),(45,'Air Fryer (Smart)',129,'air_fryer_smart.jpg','App-controlled air fryer with preset cooking programs.'),(46,'Retro Gaming Handheld Console',79,'gaming_handheld_retro.jpg','Handheld device pre-loaded with classic video games.'),(47,'Label Maker (Thermal)',45,'label_maker_thermal.jpg','Portable thermal label maker for home and office organization.'),(48,'Smart Backpack',189,'backpack_smart.jpg','Backpack with a built-in charging port and anti-theft features.'),(49,'Home Weather Station',119,'weather_station_home.jpg','Digital station with outdoor sensor for real-time weather monitoring.'),(50,'Digital Photo Frame (Wi-Fi)',159,'photo_frame_digital_wifi.jpg','Frame that rotates photos sent wirelessly from a phone.'),(51,'Stylus Pen (Active)',89,'stylus_pen_active.jpg','Active stylus with tilt and pressure sensitivity for tablets.'),(52,'Mini Drone with Camera',229,'drone_mini_camera.jpg','Small, foldable drone with a 1080p camera for beginners.');
/*!40000 ALTER TABLE `Products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Age` int NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (8,'user','Example_User','Example.User@gmail.com',30,'BPiZbadjt6lpsQKO4wB1aerzpjVIbdqyEdUSyFud+Ps='),(9,'example','Tom','tom.example@gmail.com',35,'UNhY4JhezH9gQYqvDMWrWH9CwlcKiECVqejMrND2VFw=');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-10-03  8:46:36
