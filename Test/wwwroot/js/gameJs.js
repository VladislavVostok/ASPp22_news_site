const canvas = document.getElementById("gameCanvas");
const ctx = canvas.getContext("2d");
const scoreElement = document.getElementById("score");

const box = 20;
let score = 0;
let gameSpeed = 1000;

let snake = [{ x: 9 * box, y: 6 * box }];

let dir = null;

function changeDirection(event) {
    if (event.key === "ArrowUp" && dir !== "DOWN") dir = "UP";
    else if (event.key === "ArrowDown" && dir !== "UP") dir = "DOWN";
    else if (event.key === "ArrowLeft" && dir !== "RIGHT") dir = "LEFT";
    else if (event.key === "ArrowRight" && dir !== "LEFT") dir = "RIGHT";

}

function isGameOver() {
    // Столкновение со стеной
    if (
        snake[0].x < 0 ||
        snake[0].x >= canvas.width ||
        snake[0].y < 0 ||
        snake[0].y >= canvas.height
    ) {
        return true;
    }

    // Столкновение с собой
    for (let i = 1; i < snake.length; i++) {
        if (snake[0].x === snake[i].x && snake[0].y === snake[i].y) {
            return true;
        }
    }

    return false;
}

function getCoordFood() {

    let food = {};
    food.x = Math.floor(Math.random() * 20) * box;
    food.y = Math.floor(Math.random() * 20) * box;


    while (true) {

        if (
            food.x < 0 ||
            food.x >= canvas.width ||
            food.y < 0 ||
            food.y >= canvas.height
        ) {
            food.x = Math.floor(Math.random() * 20) * box;
            food.y = Math.floor(Math.random() * 20) * box;
        }
        else {
            return food
        }
    }

    return food;
}

function gameLoop() {
    //if (isGameOver()) {
    //    alert("Игра окончена! Счёт: " + score);
    //    document.location.reload();
    //    return;
    //}


    ctx.fillStyle = "#fff";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    for (let i = 0; i < snake.length; i++) {
        ctx.fillStyle = i === 0 ? "#4caf50" : "#8bc34a";
        ctx.fillRect(snake[i].x, snake[i].y, box, box);
        ctx.fillStyle = "#fff";
        ctx.strokeRect(snake[i].x, snake[i].y, box, box);
    }

    dir = "UP";

    ctx.fillStyle = "#ff5722";
    let food = getCoordFood();
    ctx.fillRect(food.x, food.y, box, box);

    // Двигаем змейку
    let head = { x: snake[0].x, y: snake[0].y };
    if (dir === "UP") head.y -= box;
    if (dir === "DOWN") head.y += box;
    if (dir === "LEFT") head.x -= box;
    if (dir === "RIGHT") head.x += box;

    if (head.x === food.x && head.y === food.y) {
        score++;
        scoreElement.textContent = "Счёт: " + score;
        food = getCoordFood();
    }
    else {
        snake.pop();
    }

    snake.unshift(head);
    setTimeout(gameLoop, gameSpeed);


}

gameLoop();