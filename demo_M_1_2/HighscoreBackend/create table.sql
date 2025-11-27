CREATE TABLE `highscores` (
  `id` int(11) NOT NULL,
  `score` int(11) NOT NULL,
  `name` varchar(6) NOT NULL,
  `time` timestamp NOT NULL,
  `source` varchar(128) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `highscores`
--

INSERT INTO `highscores` (`id`, `score`, `name`, `time`, `source`) VALUES
(1, 67, 'silvan', '2025-11-25 13:17:49', 'db');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `highscores`
--
ALTER TABLE `highscores`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `highscores`
--
ALTER TABLE `highscores`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
