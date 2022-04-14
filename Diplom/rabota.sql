-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jun 17, 2021 at 04:49 PM
-- Server version: 5.7.24
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `rabota`
--

-- --------------------------------------------------------

--
-- Table structure for table `authorization`
--

CREATE TABLE `authorization` (
  `id` int(11) NOT NULL,
  `Login` varchar(100) NOT NULL,
  `Pass` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `authorization`
--

INSERT INTO `authorization` (`id`, `Login`, `Pass`) VALUES
(1, 'Работник', '123'),
(2, 'Заказчик', '456');

-- --------------------------------------------------------

--
-- Table structure for table `podital`
--

CREATE TABLE `podital` (
  `id` int(11) NOT NULL,
  `поставщик` varchar(100) NOT NULL,
  `деталь` varchar(100) NOT NULL,
  `дата_получения` varchar(100) NOT NULL,
  `количество` varchar(100) NOT NULL,
  `итог` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `rabotniki`
--

CREATE TABLE `rabotniki` (
  `id` int(11) NOT NULL,
  `имя` varchar(100) NOT NULL,
  `специальность` varchar(100) NOT NULL,
  `стаж` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `rabotniki`
--

INSERT INTO `rabotniki` (`id`, `имя`, `специальность`, `стаж`) VALUES
(1, 'Гришанин Анатолий Алексеевич', 'программист', '1 год'),
(3, 'Гришанин Анатолий Иванович', 'зам Ген. директора', '45 лет');

-- --------------------------------------------------------

--
-- Table structure for table `vidrabot`
--

CREATE TABLE `vidrabot` (
  `id` int(11) NOT NULL,
  `виды_работ` varchar(100) NOT NULL,
  `работники` varchar(100) NOT NULL,
  `заказчик` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `детали`
--

CREATE TABLE `детали` (
  `id` int(11) NOT NULL,
  `детали` varchar(100) NOT NULL,
  `количество` varchar(100) NOT NULL,
  `цена` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `клиент`
--

CREATE TABLE `клиент` (
  `id` int(11) NOT NULL,
  `имя_заказчика` varchar(100) NOT NULL,
  `транспортное_средство` varchar(100) NOT NULL,
  `вид_поломки` varchar(100) NOT NULL,
  `цена_восстановления` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `сведения`
--

CREATE TABLE `сведения` (
  `id` int(11) NOT NULL,
  `имя_заказчика` varchar(100) NOT NULL,
  `имя_спец` varchar(100) NOT NULL,
  `транспортное_средство` varchar(100) NOT NULL,
  `вид_работ` varchar(100) NOT NULL,
  `итог` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `authorization`
--
ALTER TABLE `authorization`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `podital`
--
ALTER TABLE `podital`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `rabotniki`
--
ALTER TABLE `rabotniki`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `vidrabot`
--
ALTER TABLE `vidrabot`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `детали`
--
ALTER TABLE `детали`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `клиент`
--
ALTER TABLE `клиент`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `сведения`
--
ALTER TABLE `сведения`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `authorization`
--
ALTER TABLE `authorization`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `podital`
--
ALTER TABLE `podital`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `rabotniki`
--
ALTER TABLE `rabotniki`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `vidrabot`
--
ALTER TABLE `vidrabot`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `детали`
--
ALTER TABLE `детали`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `клиент`
--
ALTER TABLE `клиент`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `сведения`
--
ALTER TABLE `сведения`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
