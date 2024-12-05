-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 05-12-2024 a las 14:53:38
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `system`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `calendar`
--

CREATE TABLE `calendar` (
  `code` int(11) NOT NULL,
  `daysSelec` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `calendar`
--

INSERT INTO `calendar` (`code`, `daysSelec`) VALUES
(1, 'Lunes'),
(2, 'Martes'),
(3, 'Miércoles'),
(4, 'Jueves'),
(5, 'Viernes'),
(6, 'Sábado'),
(7, 'Domingo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `charge`
--

CREATE TABLE `charge` (
  `code` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `details` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `charge`
--

INSERT INTO `charge` (`code`, `name`, `details`) VALUES
(0, '', ''),
(1, 'A', 'A'),
(2, 'B', 'B'),
(3, 'C', 'C');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `employee`
--

CREATE TABLE `employee` (
  `code` int(11) NOT NULL,
  `codeSpeciality` int(11) NOT NULL,
  `codeCharge` int(11) NOT NULL,
  `names` varchar(255) NOT NULL,
  `lastNames` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `telephone` int(11) NOT NULL,
  `mail` varchar(255) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `employee`
--

INSERT INTO `employee` (`code`, `codeSpeciality`, `codeCharge`, `names`, `lastNames`, `address`, `telephone`, `mail`, `status`) VALUES
(1, 0, 0, 'Rebe', 'Siro', 'Res. Yupa', 2147483647, '@gmail.com', 'A'),
(2, 0, 0, 'Manuel', 'Luis', 'El Tocuyo', 2147483647, '@hotmail.com', 'A'),
(3, 0, 0, 'Ruth', 'Silva', 'Los Alamos', 2147483647, '@yahoo.com', 'A'),
(4, 0, 0, 'Miguel', 'Silva', 'Yupa', 2147483647, '@hotmail.com', 'A'),
(5, 0, 0, 'Reannys Andreina', 'Romero Alvarez', 'Yupa', 2147483647, '@gmaiñ.com', 'A'),
(6, 0, 0, 'a', 'a', 'a', 1, 'qqqqqq', 'A'),
(7, 0, 0, 'a', 'a', 'a', 2, 'a', 'A'),
(8, 2, 3, 'aaaaa', 'aaa', 'aaaaaa', 111, 'aaa', 'A');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `employeerejection`
--

CREATE TABLE `employeerejection` (
  `code` int(11) NOT NULL,
  `employee` int(11) NOT NULL,
  `supl` int(11) NOT NULL,
  `reason` int(11) NOT NULL,
  `details` varchar(255) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `fisic_space`
--

CREATE TABLE `fisic_space` (
  `code` varchar(50) NOT NULL,
  `description` varchar(255) NOT NULL,
  `measures` double NOT NULL,
  `typespace` int(11) NOT NULL,
  `status` varchar(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `fisic_space`
--

INSERT INTO `fisic_space` (`code`, `description`, `measures`, `typespace`, `status`) VALUES
('0', 'L401', 50, 0, 'O'),
('01', 'patio', 20, 1, 'O'),
('10', 'aaaa', 111, 2, 'A'),
('2', 'Laboratorio', 5, 1, 'A'),
('3', 'Pasillo Ala B', 15, 5, 'A'),
('4', 'K205', 20, 2, 'A'),
('5', 'K101', 10, 0, 'O'),
('6', 'Pendiente 01', 50, 0, 'A'),
('7', 'Armario', 10, 0, 'O'),
('8', 'LABORATORIO 05', 50, 0, 'A'),
('9', 'Cafeteria', 100, 1, 'A');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventory`
--

CREATE TABLE `inventory` (
  `code` varchar(100) NOT NULL,
  `description` varchar(225) NOT NULL,
  `unit` int(11) NOT NULL,
  `cost` double NOT NULL,
  `stock` double NOT NULL,
  `sMin` double NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `inventory`
--

INSERT INTO `inventory` (`code`, `description`, `unit`, `cost`, `stock`, `sMin`, `status`) VALUES
('102030', 'Mopas', 2, 5, 10, 5, 'A'),
('B01', 'JABÓN', 0, 10.5, 5, 2, 'A'),
('B02', 'GAS DE AIRE', 0, 15.9, 5, 1, 'A'),
('b03', 'Cepillo', 0, 3.5, 1, 1, 'O'),
('htfghdgbc', 'aaa', 2, 1, 1, 1, 'O');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `materials`
--

CREATE TABLE `materials` (
  `codeS` int(11) NOT NULL,
  `codeInventory` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `materials`
--

INSERT INTO `materials` (`codeS`, `codeInventory`) VALUES
(10, 'B02'),
(11, 'B01'),
(11, 'B02'),
(12, 'B01'),
(12, 'B02');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `organization`
--

CREATE TABLE `organization` (
  `rif` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `boss` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `organization`
--

INSERT INTO `organization` (`rif`, `name`, `address`, `boss`) VALUES
('J-29972410', 'Decanato de ciencias y tecnología', 'Avenida florencio, Barquisimeto', 'Rebeca Silva');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `planservice`
--

CREATE TABLE `planservice` (
  `code` int(11) NOT NULL,
  `codeService` int(11) NOT NULL,
  `codeEmployee` int(11) NOT NULL,
  `codeSupl` int(11) NOT NULL,
  `codeFisicS` int(11) NOT NULL,
  `daysSelec` varchar(255) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `planservice`
--

INSERT INTO `planservice` (`code`, `codeService`, `codeEmployee`, `codeSupl`, `codeFisicS`, `daysSelec`, `status`) VALUES
(1, 1, 2, 3, 2, '0000-00-00', 'A'),
(2, 1, 2, 4, 4, '0000-00-00', 'A'),
(3, 1, 2, 3, 8, '0000-00-00', 'A'),
(4, 2, 4, 2, 2, '0000-00-00', 'A'),
(5, 2, 3, 4, 4, '0000-00-00', 'A'),
(6, 2, 2, 3, 9, '0000-00-00', 'A'),
(7, 2, 3, 5, 2, '0000-00-00', 'A'),
(8, 2, 3, 5, 2, '0000-00-00', 'A'),
(9, 2, 3, 4, 6, '0000-00-00', 'A'),
(10, 2, 3, 2, 6, '0000-00-00', 'A'),
(11, 2, 5, 5, 2, '0000-00-00', 'A'),
(12, 2, 3, 4, 2, '2024-12-26', 'A');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rejection`
--

CREATE TABLE `rejection` (
  `code` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  `details` varchar(255) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `rejection`
--

INSERT INTO `rejection` (`code`, `description`, `details`, `status`) VALUES
(1, 'Enfermedad', 'El empleado se encontraba enfermo y tenía permiso de ausencia', 'A'),
(2, 'Enfermedad NP', 'El empleado faltó por enfermedad sin justificativo médico', 'A');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `services`
--

CREATE TABLE `services` (
  `code` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  `sType` int(11) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `services`
--

INSERT INTO `services` (`code`, `description`, `sType`, `status`) VALUES
(1, 'Pintar paredes', 1, 'A'),
(2, 'Arreglar aire acondicionado', 1, 'A');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `speciality`
--

CREATE TABLE `speciality` (
  `code` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `details` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `speciality`
--

INSERT INTO `speciality` (`code`, `name`, `details`) VALUES
(1, 'Tecnico', 'Especialistas en equipos tecnológicos'),
(2, 'Limpieza', 'Limpieza general'),
(3, 'Pintor', 'Encargado de pintar paredes y puertas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `type_fisicspace`
--

CREATE TABLE `type_fisicspace` (
  `code` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `type_fisicspace`
--

INSERT INTO `type_fisicspace` (`code`, `description`) VALUES
(1, 'PATIO'),
(2, 'LABORATORIO'),
(3, 'SALON'),
(4, 'OFICINA'),
(5, 'PASILLO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `type_services`
--

CREATE TABLE `type_services` (
  `code` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `type_services`
--

INSERT INTO `type_services` (`code`, `description`) VALUES
(1, 'MANTENIMIENTO'),
(2, 'LIMPIEZA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `unit`
--

CREATE TABLE `unit` (
  `code` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `unit`
--

INSERT INTO `unit` (`code`, `description`) VALUES
(1, 'LITROS'),
(2, 'KILOS'),
(3, 'UNIDAD');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `user`
--

CREATE TABLE `user` (
  `code` int(11) NOT NULL,
  `userName` varchar(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `type` int(11) NOT NULL,
  `mail` varchar(255) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `user`
--

INSERT INTO `user` (`code`, `userName`, `name`, `password`, `type`, `mail`, `status`) VALUES
(1, 'Test', 'Prueba', '12345', 2, 'a', 'A'),
(2, 'Rebe', 'Rebeca Silva', '1808', 1, 'rebefsilva1808@gmail.com', 'A'),
(3, 'Maedluar', 'Manuel Luis', '121297', 3, 'manuelluis@gmail.com', 'A'),
(4, 'aa', 'a', '123', 1, 'a', 'A');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usertype`
--

CREATE TABLE `usertype` (
  `code` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usertype`
--

INSERT INTO `usertype` (`code`, `description`) VALUES
(1, 'ADMINISTRADOR'),
(2, 'PERSONAL'),
(3, 'GESTOR');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `calendar`
--
ALTER TABLE `calendar`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `charge`
--
ALTER TABLE `charge`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`code`) USING BTREE;

--
-- Indices de la tabla `employeerejection`
--
ALTER TABLE `employeerejection`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `fisic_space`
--
ALTER TABLE `fisic_space`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `materials`
--
ALTER TABLE `materials`
  ADD PRIMARY KEY (`codeS`,`codeInventory`) USING BTREE;

--
-- Indices de la tabla `organization`
--
ALTER TABLE `organization`
  ADD PRIMARY KEY (`rif`);

--
-- Indices de la tabla `planservice`
--
ALTER TABLE `planservice`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `rejection`
--
ALTER TABLE `rejection`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `speciality`
--
ALTER TABLE `speciality`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `type_fisicspace`
--
ALTER TABLE `type_fisicspace`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `type_services`
--
ALTER TABLE `type_services`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `unit`
--
ALTER TABLE `unit`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`code`);

--
-- Indices de la tabla `usertype`
--
ALTER TABLE `usertype`
  ADD PRIMARY KEY (`code`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
