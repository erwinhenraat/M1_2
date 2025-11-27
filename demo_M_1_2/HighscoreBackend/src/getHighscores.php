<?php
$env = parse_ini_file('.env');
$conn = new mysqli($env["HOST"], $env["USER"], $env["PASSWORD"], $env["DATABASE"]);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM `highscores`";
$results = $conn->query($sql);

header('Content-Type: application/json; charset=utf-8');
echo json_encode($results->fetch_all(MYSQLI_ASSOC));

