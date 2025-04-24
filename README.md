Docker:
1. Нужно создать файл ".env" на основе ".env.example" в папке где лежит docker-compose файл).
2. Засетать свои значения для переменных (в частности пароль).
3. Вызвать "cmd" в папке, где лежит docker-compose файл.
4. Выполнить "docker-compose up --build".

Postman:
1. Запустить Postman.
2. Выполнить импорт "Newborn Registry API.postman_collection.json" файла в Postman.
3. Для тестирования в Docker в коллекции "Newborn Registry API" в Variables в "baseUrl" указать Current value "http://localhost:8080".
4. Для тестирования локально через API в коллекции "Newborn Registry API" в Variables в "baseUrl" указать Current value "https://localhost:7084".
