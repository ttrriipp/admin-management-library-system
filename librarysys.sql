-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 24, 2025 at 03:54 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `librarysys`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_acc`
--

CREATE TABLE `admin_acc` (
  `id` int(10) NOT NULL,
  `username` varchar(15) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin_acc`
--

INSERT INTO `admin_acc` (`id`, `username`, `password`) VALUES
(1, 'admin1', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `id` int(11) NOT NULL,
  `title` varchar(200) NOT NULL,
  `author` varchar(50) NOT NULL,
  `ISBN` bigint(30) NOT NULL,
  `category` enum('History','Technology','Fiction','Mathematics','Science','English') NOT NULL,
  `quantity` bigint(10) NOT NULL,
  `status` enum('Active','Inactive','','') NOT NULL DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`id`, `title`, `author`, `ISBN`, `category`, `quantity`, `status`) VALUES
(1, 'Digital Fortress', 'Dan Brown', 9780552151696, 'Technology', 10, 'Active'),
(2, 'A Brief History of Time', 'Stephen Hawking', 9780553176988, 'Science', 7, 'Active'),
(3, 'To Kill a Mockingbird', 'Harper Lee', 9780061120084, 'English', 5, 'Active'),
(4, '1984', 'George Orwell', 9780451524935, 'Fiction', 9, 'Active'),
(5, 'Calculus Made Easy', 'Silvanus P. Thompson', 9780312185480, 'Mathematics', 6, 'Active'),
(6, 'The Art of War', 'Sun Tzu', 9781590302255, 'History', 8, 'Active'),
(7, 'The Selfish Gene', 'Richard Dawkins', 9780192860927, 'Science', 4, 'Active'),
(8, 'The Great Gatsby', 'F. Scott Fitzgerald', 9780743273565, 'Fiction', 5, 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `loans`
--

CREATE TABLE `loans` (
  `id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL,
  `student_id` int(11) NOT NULL,
  `issue_date` date NOT NULL,
  `due_date` date NOT NULL,
  `return_date` date DEFAULT NULL,
  `status` varchar(20) NOT NULL,
  `fine_amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `issued_by` int(11) NOT NULL,
  `notes` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `loans`
--

INSERT INTO `loans` (`id`, `book_id`, `student_id`, `issue_date`, `due_date`, `return_date`, `status`, `fine_amount`, `issued_by`, `notes`) VALUES
(1, 1, 1, '2025-05-01', '2025-05-15', NULL, 'Active', 0.00, 1, 'First borrowing'),
(2, 2, 2, '2025-05-02', '2025-05-16', '2025-05-15', 'Returned', 0.00, 1, ''),
(3, 3, 3, '2025-05-03', '2025-05-30', NULL, 'Active', 10.00, 1, 'Late return'),
(4, 4, 4, '2025-05-04', '2025-05-18', NULL, 'Active', 0.00, 1, ''),
(5, 5, 5, '2025-05-05', '2025-05-19', NULL, 'Lost', 200.00, 1, 'Book lost');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `id` int(11) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `department` varchar(50) NOT NULL,
  `course` varchar(50) NOT NULL,
  `status` enum('Active','Inactive','','') NOT NULL DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`id`, `last_name`, `first_name`, `email`, `department`, `course`, `status`) VALUES
(1, 'Garcia', 'Maria', 'maria.garcia@example.com', 'CAS', 'BSCS', 'Active'),
(2, 'Santos', 'Juan', 'juan.santos@example.com', 'CBA', 'BSA', 'Active'),
(3, 'Reyes', 'Ana', 'ana.reyes@example.com', 'COE', 'BSCE', 'Active'),
(4, 'Cruz', 'Luis', 'luis.cruz@example.com', 'CCS', 'BSIT', 'Active'),
(5, 'Torres', 'Elena', 'elena.torres@example.com', 'CAS', 'BSMath', 'Active'),
(6, 'Flores', 'Miguel', 'miguel.flores@example.com', 'CAS', 'BSPsy', 'Active');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin_acc`
--
ALTER TABLE `admin_acc`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `title` (`title`);

--
-- Indexes for table `loans`
--
ALTER TABLE `loans`
  ADD PRIMARY KEY (`id`),
  ADD KEY `book_id` (`book_id`),
  ADD KEY `student_id` (`student_id`),
  ADD KEY `issued_by` (`issued_by`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin_acc`
--
ALTER TABLE `admin_acc`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `loans`
--
ALTER TABLE `loans`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `loans`
--
ALTER TABLE `loans`
  ADD CONSTRAINT `loans_ibfk_1` FOREIGN KEY (`book_id`) REFERENCES `books` (`id`) ON UPDATE NO ACTION,
  ADD CONSTRAINT `loans_ibfk_2` FOREIGN KEY (`student_id`) REFERENCES `students` (`id`),
  ADD CONSTRAINT `loans_ibfk_3` FOREIGN KEY (`issued_by`) REFERENCES `admin_acc` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
