export class Photo {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.img = data.img
        this.description = data.description
        this.creator = data.creator
        this.creatorId = data.creatorId
    }
}
// const data = {
//     "id": 1,
//     "createdAt": "2023-12-06T22:38:01",
//     "updatedAt": "2023-12-06T22:38:01",
//     "name": "Telluride",
//     "img": "https://images.unsplash.com/photo-1602603362578-8a6bc48bfc24?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8VGVsbHVyaWRlfGVufDB8fDB8fHww",
//     "description": "Take your vacation to a new level",
//     "creatorId": "652ef49aff9881f8395eb350",
//     "creator": {
//         "id": "652ef49aff9881f8395eb350",
//         "name": "Laura",
//         "email": "lauraalspaugh2002@icloud.com",
//         "picture": "https://images.unsplash.com/photo-1617659258448-f2711883be96?w=800&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fGJsYWNrJTIwYW5kJTIwd2hpdGUlMjBhZXN0aGV0aWN8ZW58MHx8MHx8fDA%3D"
//     }
