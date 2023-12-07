CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS photos(
        id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name CHAR(255) NOT NULL,
        img VARCHAR(1000) NOT NULL,
        description VARCHAR(1000) NOT NULL,
        creatorId CHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS favorites(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        photoId INT NOT NULL,
        accountId VARCHAR(255) NOT NULL,
        FOREIGN KEY (photoId) REFERENCES photos (id) ON DELETE CASCADE,
        FOREIGN KEY (accountId) REFERENCES accounts (id) ON DELETE CASCADE,
        UNIQUE(photoId, accountID)
    ) default charset utf8 COMMENT '';

INSERT INTO
    photos(
        name,
        img,
        description,
        creatorId
    )
VALUES (
        "Telluride",
        "https://images.unsplash.com/photo-1602603362578-8a6bc48bfc24?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8VGVsbHVyaWRlfGVufDB8fDB8fHww",
        "Take your vacation to a new level",
        "652ef49aff9881f8395eb350"
    )

SELECT * FROM photos

SELECT * FROM favorites