<?php
$env = parse_ini_file('.env');
$conn = new mysqli($env["HOST"], $env["USER"], $env["PASSWORD"], $env["DATABASE"]);
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$data = json_decode(file_get_contents('php://input'), true);
if(!$data){
    die("No json in body found");
}
$score = $data["score"];
$name = $data["name"];
$src = $data["source"];
$time = time();
$stmt = $conn->prepare("INSERT INTO `highscores` (`score`, `name`, `time`, `source`) VALUES(?, ?, FROM_UNIXTIME(?), ?)");
$stmt->bind_param("isis", $score, $name, $time, $src);

if($stmt->execute()){
    http_response_code(201);
    echo "Succes! Score added!";
} else {
    http_response_code(500);
    header('Content-Type: application/json; charset=utf-8');
    echo json_encode(["status" => "error", "message" => "uwu could not save score due to a server error.", "error"=>$stmt->error]);
}