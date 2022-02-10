-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Dec 04, 2021 at 08:03 AM
-- Server version: 10.4.18-MariaDB
-- PHP Version: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `react`
--

-- --------------------------------------------------------

--
-- Table structure for table `Cliente`
--

CREATE TABLE `Cliente` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(400) NOT NULL,
  `usuario` varchar(100) NOT NULL,
  `pass` varchar(50) NOT NULL,
  `imagen` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Cliente`
--

INSERT INTO `Cliente` (`id`, `nombre`, `descripcion`, `usuario`, `pass`, `imagen`) VALUES
(2, 'juan jose', 'perez', 'andres', '12345', '1'),
(3, 'juan', 'perez', 'andres', '12345', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `Comentario`
--

CREATE TABLE `Comentario` (
  `id` int(11) NOT NULL,
  `comentario` varchar(300) NOT NULL,
  `cliente` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `Empleado`
--

CREATE TABLE `Empleado` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(400) NOT NULL,
  `restaurante_id` int(11) NOT NULL,
  `imagen` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Empleado`
--

INSERT INTO `Empleado` (`id`, `nombre`, `descripcion`, `restaurante_id`, `imagen`) VALUES
(2, 'jhon', 'cajero', 1, ''),
(3, 'pedro', 'pote', 1, NULL),
(4, 'luis', 'ortiz', 1, NULL),
(5, 'pedro', 'morales', 1, NULL),
(6, 'juan', 'perez', 1, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `Pedido`
--

CREATE TABLE `Pedido` (
  `id` int(11) NOT NULL,
  `cliente` int(11) NOT NULL,
  `plato` int(11) NOT NULL,
  `fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Pedido`
--

INSERT INTO `Pedido` (`id`, `cliente`, `plato`, `fecha`) VALUES
(2, 3, 2, '2021-12-03 17:09:57');

-- --------------------------------------------------------

--
-- Table structure for table `Pessoa`
--

CREATE TABLE `Pessoa` (
  `Codigo` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `Endereco` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Pessoa`
--

INSERT INTO `Pessoa` (`Codigo`, `Nome`, `Endereco`) VALUES
(1, 'Pessoa 1', 'Endereço 1'),
(2, 'Pessoa 2', 'Endereço 2'),
(3, 'Pessoa 3', 'Endereço 3'),
(4, 'Pessoa 4', 'Endereço 4'),
(5, 'Pessoa 5', 'Endereço 5'),
(6, 'Pessoa 6', 'Endereço 6'),
(7, 'Pessoa 7', 'Endereço 7'),
(8, 'Pessoa 8', 'Endereço 8'),
(9, 'Pessoa 9', 'Endereço 9'),
(10, 'Pessoa 10', 'Endereço 10');

-- --------------------------------------------------------

--
-- Table structure for table `Plato`
--

CREATE TABLE `Plato` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(500) NOT NULL,
  `imagen` varchar(50) NOT NULL,
  `restaurante_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Plato`
--

INSERT INTO `Plato` (`id`, `nombre`, `descripcion`, `imagen`, `restaurante_id`) VALUES
(1, 'pastas ', 'pastas francesa, disfrutala', '', 1),
(2, 'ensalada vegetal', 'Para los veganos, con alta vitamina ', '', 1),
(3, 'pizza ', 'pizza hawayana, disfrutala', '', 1);

-- --------------------------------------------------------

--
-- Table structure for table `Reserva`
--

CREATE TABLE `Reserva` (
  `id` int(11) NOT NULL,
  `cliente` int(100) NOT NULL,
  `servicio` int(100) NOT NULL,
  `fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Reserva`
--

INSERT INTO `Reserva` (`id`, `cliente`, `servicio`, `fecha`) VALUES
(1, 3, 2, '2021-12-03 17:52:05'),
(2, 3, 1, '2021-12-03 17:52:05'),
(3, 3, 1, '2021-12-03 17:52:05'),
(5, 3, 1, '2021-12-03 17:52:05');

-- --------------------------------------------------------

--
-- Table structure for table `Restaurante`
--

CREATE TABLE `Restaurante` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(400) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Restaurante`
--

INSERT INTO `Restaurante` (`id`, `nombre`, `descripcion`) VALUES
(1, 'La Casita', 'Somos el mejor restaurante de colombia, la sactifasion es lo nuestro.');

-- --------------------------------------------------------

--
-- Table structure for table `Servicio`
--

CREATE TABLE `Servicio` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` varchar(500) NOT NULL,
  `imagen` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `Servicio`
--

INSERT INTO `Servicio` (`id`, `nombre`, `descripcion`, `imagen`) VALUES
(1, 'Matrimonio', 'Es lo mejor, comprometete con esa persona que amas.', ''),
(2, 'Cena con amigos', 'Reunete y comparte con esas personas que siempre estan para ti.', ''),
(3, 'cumpleaños', 'Es lo mejor, comprometete con esa persona que amas.', ''),
(4, 'Cenas ejecutivas', 'Preparamos el mejor ambiente ejecutivo para reuniones importantes!', NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Cliente`
--
ALTER TABLE `Cliente`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Comentario`
--
ALTER TABLE `Comentario`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Empleado`
--
ALTER TABLE `Empleado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `restaurante_id` (`restaurante_id`);

--
-- Indexes for table `Pedido`
--
ALTER TABLE `Pedido`
  ADD PRIMARY KEY (`id`),
  ADD KEY `plato` (`plato`),
  ADD KEY `cliente` (`cliente`);

--
-- Indexes for table `Pessoa`
--
ALTER TABLE `Pessoa`
  ADD PRIMARY KEY (`Codigo`);

--
-- Indexes for table `Plato`
--
ALTER TABLE `Plato`
  ADD PRIMARY KEY (`id`),
  ADD KEY `restaurante_id` (`restaurante_id`);

--
-- Indexes for table `Reserva`
--
ALTER TABLE `Reserva`
  ADD PRIMARY KEY (`id`),
  ADD KEY `servicio` (`servicio`),
  ADD KEY `cliente` (`cliente`);

--
-- Indexes for table `Restaurante`
--
ALTER TABLE `Restaurante`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Servicio`
--
ALTER TABLE `Servicio`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Cliente`
--
ALTER TABLE `Cliente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `Comentario`
--
ALTER TABLE `Comentario`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `Empleado`
--
ALTER TABLE `Empleado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `Pedido`
--
ALTER TABLE `Pedido`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `Pessoa`
--
ALTER TABLE `Pessoa`
  MODIFY `Codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `Plato`
--
ALTER TABLE `Plato`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `Reserva`
--
ALTER TABLE `Reserva`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `Servicio`
--
ALTER TABLE `Servicio`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Comentario`
--
ALTER TABLE `Comentario`
  ADD CONSTRAINT `Comentario_ibfk_1` FOREIGN KEY (`id`) REFERENCES `Cliente` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Empleado`
--
ALTER TABLE `Empleado`
  ADD CONSTRAINT `Empleado_ibfk_1` FOREIGN KEY (`restaurante_id`) REFERENCES `Restaurante` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Pedido`
--
ALTER TABLE `Pedido`
  ADD CONSTRAINT `Pedido_ibfk_3` FOREIGN KEY (`cliente`) REFERENCES `Cliente` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Pedido_ibfk_4` FOREIGN KEY (`id`) REFERENCES `Plato` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Plato`
--
ALTER TABLE `Plato`
  ADD CONSTRAINT `Plato_ibfk_1` FOREIGN KEY (`restaurante_id`) REFERENCES `Restaurante` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `Reserva`
--
ALTER TABLE `Reserva`
  ADD CONSTRAINT `Reserva_ibfk_2` FOREIGN KEY (`servicio`) REFERENCES `Servicio` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Reserva_ibfk_3` FOREIGN KEY (`cliente`) REFERENCES `Cliente` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
