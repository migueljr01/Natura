-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 26-Set-2020 às 15:12
-- Versão do servidor: 10.4.14-MariaDB
-- versão do PHP: 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `natura`
--
CREATE DATABASE IF NOT EXISTS `natura` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `natura`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `clientes`
--

CREATE TABLE `clientes` (
  `idCliente` int(11) NOT NULL,
  `nomeCliente` varchar(100) NOT NULL,
  `enderecoCliente` varchar(200) NOT NULL,
  `bairroCliente` varchar(50) NOT NULL,
  `cidadeCliente` varchar(50) NOT NULL,
  `cepCliente` varchar(10) NOT NULL,
  `emailCliente` varchar(100) NOT NULL,
  `identidadeCliente` varchar(50) NOT NULL,
  `cpfCliente` varchar(20) NOT NULL,
  `limiteCliente` int(6) NOT NULL,
  `ativoCliente` int(11) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `clientes`
--

INSERT INTO `clientes` (`idCliente`, `nomeCliente`, `enderecoCliente`, `bairroCliente`, `cidadeCliente`, `cepCliente`, `emailCliente`, `identidadeCliente`, `cpfCliente`, `limiteCliente`, `ativoCliente`) VALUES
(1, 'Miguel Verissimo Jose Martins Junior', 'Servidão Leonel Domingos da Silva, 93', 'Ingleses do Rio Vermelhoa', 'Florianópolisa', '88058-730', 'test@test.com', '999999999999', '999999999999', 1000, 1),
(2, 'Karine Rodrigues de Souza', 'Servidão Leonel Domingos da Silva,93', 'Ingleses do Rio Vermelho', 'Florianópolis', '88058730', 'test@test.com', '99999999', '999999999999', 9000, 1),
(7, 'Antonio Carlos de Souza', 'Servidão Leonel domingos da Silva,93', 'Inglesses do Rio Vermelho', 'Florianópolis', '88058730', 'test@teste', '9999999999', '99999999999', 1000, 1),
(8, 'Alexandrer Luthor 1', 'adasdasdas', 'assss', 'asss', '9999999', 'teste@teste', '999999999999', '999999999999', 99999, 1),
(9, '', '', '', '', '', '', '', '', 0, 0),
(10, 'Clark Kent', 'Kent Farm ', '', 'Smallville', '888888888', 'smallville@super.com', '999999999', '999999999', 1000, 0);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`idCliente`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `clientes`
--
ALTER TABLE `clientes`
  MODIFY `idCliente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
