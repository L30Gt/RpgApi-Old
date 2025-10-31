# RPG API Documentation

## Overview
This is a RESTful API for an RPG (Role-Playing Game) management system. The API allows you to manage characters, weapons, users, skills, and battles.

**Base URL**: `https://your-api-domain.com/`

**Content-Type**: `application/json`

---

## Table of Contents
- [Personagens (Characters)](#personagens-characters)
- [Armas (Weapons)](#armas-weapons)
- [Usuarios (Users)](#usuarios-users)
- [Disputas (Battles)](#disputas-battles)
- [PersonagemHabilidades (Character Skills)](#personagemhabilidades-character-skills)
- [PersonagensExemplo (Example Characters)](#personagensexemplo-example-characters)
- [PersonagensExercicio (Exercise Characters)](#personagensexercicio-exercise-characters)

---

## Personagens (Characters)

### Get Single Character
**Endpoint**: `GET /Personagens/{id}`

**Description**: Retrieves a single character by ID, including weapon, user, and skills.

**Parameters**:
- `id` (path, integer, required): Character ID

**Response Example**:
```json
{
  "id": 1,
  "nome": "Aragorn",
  "pontosVida": 100,
  "forca": 20,
  "defesa": 18,
  "inteligencia": 15,
  "classe": 1,
  "fotoPersonagem": null,
  "arma": {
    "id": 1,
    "nome": "Anduril",
    "dano": 30
  },
  "personagemHabilidades": [],
  "disputas": 0,
  "vitorias": 0,
  "derrotas": 0
}
```

---

### Get All Characters
**Endpoint**: `GET /Personagens/GetAll`

**Description**: Retrieves all characters in the system.

**Response Example**:
```json
[
  {
    "id": 1,
    "nome": "Aragorn",
    "pontosVida": 100,
    "forca": 20,
    "defesa": 18,
    "inteligencia": 15,
    "classe": 1
  }
]
```

---

### Create Character
**Endpoint**: `POST /Personagens`

**Description**: Creates a new character.

**Request Body**:
```json
{
  "nome": "Legolas",
  "pontosVida": 90,
  "forca": 18,
  "defesa": 15,
  "inteligencia": 20,
  "classe": 2
}
```

**Validation**:
- `pontosVida` must not exceed 100

**Response**: Returns the ID of the created character
```json
1
```

---

### Update Character
**Endpoint**: `PUT /Personagens`

**Description**: Updates an existing character.

**Request Body**:
```json
{
  "id": 1,
  "nome": "Aragorn Updated",
  "pontosVida": 95,
  "forca": 22,
  "defesa": 19,
  "inteligencia": 16,
  "classe": 1
}
```

**Validation**:
- `pontosVida` must not exceed 100

**Response**: Returns the number of affected rows
```json
1
```

---

### Delete Character
**Endpoint**: `DELETE /Personagens/{id}`

**Description**: Deletes a character by ID.

**Parameters**:
- `id` (path, integer, required): Character ID

**Response**: Returns the number of affected rows
```json
1
```

---

### Restore Character Health
**Endpoint**: `PUT /Personagens/RestaurarPontosVida`

**Description**: Restores a character's health points to 100.

**Request Body**:
```json
{
  "id": 1
}
```

**Response**: Returns the number of affected rows
```json
1
```

---

### Update Character Photo
**Endpoint**: `PUT /Personagens/AtualizarFoto`

**Description**: Updates a character's photo.

**Request Body**:
```json
{
  "id": 1,
  "fotoPersonagem": "base64_encoded_image_data"
}
```

**Response**: Returns the number of affected rows
```json
1
```

---

### Reset Character Ranking
**Endpoint**: `PUT /Personagens/ZerarRanking`

**Description**: Resets a character's battle statistics (disputes, victories, defeats).

**Request Body**:
```json
{
  "id": 1
}
```

**Response**: Returns the number of affected rows
```json
1
```

---

### Reset All Rankings and Restore All Lives
**Endpoint**: `PUT /Personagens/ZerarRankingRestaurarVidas`

**Description**: Resets all characters' battle statistics and restores health points.

**Response**:
```json
"Disputas e pontos de vida resetados"
```

---

### Get Characters by User
**Endpoint**: `GET /Personagens/GetByUser/{userId}`

**Description**: Retrieves all characters belonging to a specific user.

**Parameters**:
- `userId` (path, integer, required): User ID

**Response Example**:
```json
[
  {
    "id": 1,
    "nome": "Aragorn",
    "pontosVida": 100,
    "forca": 20,
    "defesa": 18,
    "inteligencia": 15,
    "classe": 1
  }
]
```

---

### Get Characters by User Profile
**Endpoint**: `GET /Personagens/GetByPerfil/{userId}`

**Description**: Retrieves characters based on user profile. Admins see all characters, regular users see only their own.

**Parameters**:
- `userId` (path, integer, required): User ID

**Response Example**:
```json
[
  {
    "id": 1,
    "nome": "Aragorn",
    "pontosVida": 100,
    "forca": 20,
    "defesa": 18,
    "inteligencia": 15,
    "classe": 1
  }
]
```

---

## Armas (Weapons)

### Get Single Weapon
**Endpoint**: `GET /Armas/{id}`

**Description**: Retrieves a single weapon by ID.

**Parameters**:
- `id` (path, integer, required): Weapon ID

**Response Example**:
```json
{
  "id": 1,
  "nome": "Anduril",
  "dano": 30,
  "personagemId": 1
}
```

---

### Get All Weapons
**Endpoint**: `GET /Armas/GetAll`

**Description**: Retrieves all weapons in the system.

**Response Example**:
```json
[
  {
    "id": 1,
    "nome": "Anduril",
    "dano": 30,
    "personagemId": 1
  }
]
```

---

### Create Weapon
**Endpoint**: `POST /Armas`

**Description**: Creates a new weapon and assigns it to a character.

**Request Body**:
```json
{
  "nome": "Glamdring",
  "dano": 35,
  "personagemId": 2
}
```

**Validation**:
- `dano` must not be 0
- Character must exist
- Character must not already have a weapon

**Response**: Returns the ID of the created weapon
```json
1
```

---

### Update Weapon
**Endpoint**: `PUT /Armas`

**Description**: Updates an existing weapon.

**Request Body**:
```json
{
  "id": 1,
  "nome": "Anduril Reforged",
  "dano": 35,
  "personagemId": 1
}
```

**Response**: Returns the number of affected rows
```json
1
```

---

### Delete Weapon
**Endpoint**: `DELETE /Armas/{id}`

**Description**: Deletes a weapon by ID.

**Parameters**:
- `id` (path, integer, required): Weapon ID

**Response**: Returns the number of affected rows
```json
1
```

---

## Usuarios (Users)

### Register User
**Endpoint**: `POST /Usuarios/Registrar`

**Description**: Registers a new user with encrypted password.

**Request Body**:
```json
{
  "username": "john_doe",
  "passwordString": "mySecurePassword123",
  "email": "john@example.com",
  "perfil": "Player"
}
```

**Validation**:
- Username must be unique

**Response**: Returns the ID of the created user
```json
1
```

---

### Authenticate User
**Endpoint**: `POST /Usuarios/Autenticar`

**Description**: Authenticates a user and returns user information.

**Request Body**:
```json
{
  "username": "john_doe",
  "passwordString": "mySecurePassword123"
}
```

**Response Example**:
```json
{
  "id": 1,
  "username": "john_doe",
  "email": "john@example.com",
  "perfil": "Player",
  "dataAcesso": "2023-10-15T10:30:00",
  "latitude": null,
  "longitude": null,
  "foto": null
}
```

---

### Change Password
**Endpoint**: `PUT /Usuarios/AlterarSenha`

**Description**: Changes a user's password.

**Request Body**:
```json
{
  "username": "john_doe",
  "passwordString": "newSecurePassword456"
}
```

**Response**: Returns the user ID
```json
1
```

---

### Get All Users
**Endpoint**: `GET /Usuarios/GetAll`

**Description**: Retrieves all users in the system.

**Response Example**:
```json
[
  {
    "id": 1,
    "username": "john_doe",
    "email": "john@example.com",
    "perfil": "Player",
    "dataAcesso": "2023-10-15T10:30:00"
  }
]
```

---

### Get User by ID
**Endpoint**: `GET /Usuarios/{usuarioId}`

**Description**: Retrieves a single user by ID.

**Parameters**:
- `usuarioId` (path, integer, required): User ID

**Response Example**:
```json
{
  "id": 1,
  "username": "john_doe",
  "email": "john@example.com",
  "perfil": "Player",
  "dataAcesso": "2023-10-15T10:30:00"
}
```

---

### Get User by Login
**Endpoint**: `GET /Usuarios/GetByLogin/{login}`

**Description**: Retrieves a user by username.

**Parameters**:
- `login` (path, string, required): Username

**Response Example**:
```json
{
  "id": 1,
  "username": "john_doe",
  "email": "john@example.com",
  "perfil": "Player",
  "dataAcesso": "2023-10-15T10:30:00"
}
```

---

### Update User Location
**Endpoint**: `PUT /Usuarios/AtualizarLocalizacao`

**Description**: Updates a user's geolocation coordinates.

**Request Body**:
```json
{
  "id": 1,
  "latitude": -23.5505,
  "longitude": -46.6333
}
```

**Response**: Returns the number of affected rows
```json
1
```

---

### Update User Email
**Endpoint**: `PUT /Usuarios/AtualizarEmail`

**Description**: Updates a user's email address.

**Request Body**:
```json
{
  "id": 1,
  "email": "newemail@example.com"
}
```

**Response**: Returns the number of affected rows
```json
1
```

---

### Update User Photo
**Endpoint**: `PUT /Usuarios/AtualizarFoto`

**Description**: Updates a user's profile photo.

**Request Body**:
```json
{
  "id": 1,
  "foto": "base64_encoded_image_data"
}
```

**Response**: Returns the number of affected rows
```json
1
```

---

## Disputas (Battles)

### Attack with Weapon
**Endpoint**: `POST /Disputas/Arma`

**Description**: Performs an attack using a character's weapon.

**Request Body**:
```json
{
  "atacanteId": 1,
  "oponenteId": 2
}
```

**Response Example**:
```json
{
  "id": 1,
  "atacanteId": 1,
  "oponenteId": 2,
  "narracao": " Atacante: Aragorn. Oponente: Legolas. Pontos de vida do atacante: 100. Pontos de vida do oponente: 75. Arma Utilizada: Anduril. Dano: 25.",
  "dataDisputa": "2023-10-15T10:30:00"
}
```

---

### Attack with Skill
**Endpoint**: `POST /Disputas/Habilidade`

**Description**: Performs an attack using a character's skill.

**Request Body**:
```json
{
  "atacanteId": 1,
  "oponenteId": 2,
  "habilidadeId": 3
}
```

**Response Example**:
```json
{
  "id": 2,
  "atacanteId": 1,
  "oponenteId": 2,
  "habilidadeId": 3,
  "narracao": " Atacante: Aragorn. Oponente: Legolas. Pontos de vida do atacante: 100. Pontos de vida do oponente: 60. Habilidade Utilizada: Golpe Poderoso. Dano: 15.",
  "dataDisputa": "2023-10-15T10:30:00"
}
```

---

### Random Character
**Endpoint**: `GET /Disputas/PersonagemRandom`

**Description**: Returns a randomly selected character.

**Response Example**:
```json
"Nº Sorteado 3. Personagem: Gandalf"
```

---

### Group Battle
**Endpoint**: `POST /Disputas/DisputaemGrupo`

**Description**: Simulates a battle between multiple characters until only one remains.

**Request Body**:
```json
{
  "listaIdPersonagens": [1, 2, 3, 4, 5]
}
```

**Response Example**:
```json
{
  "narracao": "Aragorn atacou Legolas usando Anduril com o dano 25. ...",
  "resultados": [
    "Aragorn atacou Legolas usando Anduril com o dano 25.",
    "Gandalf atacou Gimli usando Cajado Místico com o dano 30.",
    "ARAGORN é CAMPEÃO com 45 pontos de vida restantes!"
  ],
  "dataDisputa": "2023-10-15T10:30:00"
}
```

---

### Delete All Battles
**Endpoint**: `DELETE /Disputas/ApagarDisputas`

**Description**: Deletes all battle records from the system.

**Response**:
```json
"Disputas apagadas"
```

---

### List All Battles
**Endpoint**: `GET /Disputas/Listar`

**Description**: Retrieves all battle records.

**Response Example**:
```json
[
  {
    "id": 1,
    "atacanteId": 1,
    "oponenteId": 2,
    "narracao": " Atacante: Aragorn. Oponente: Legolas...",
    "dataDisputa": "2023-10-15T10:30:00"
  }
]
```

---

## PersonagemHabilidades (Character Skills)

### Add Skill to Character
**Endpoint**: `POST /PersonagemHabilidades`

**Description**: Assigns a skill to a character.

**Request Body**:
```json
{
  "personagemId": 1,
  "habilidadeId": 3
}
```

**Validation**:
- Character must exist
- Skill must exist

**Response**: Returns the number of affected rows
```json
1
```

---

### Get Character Skills
**Endpoint**: `GET /PersonagemHabilidades/{id}`

**Description**: Retrieves all skills for a specific character.

**Parameters**:
- `id` (path, integer, required): Character ID

**Response Example**:
```json
[
  {
    "personagemId": 1,
    "habilidadeId": 3,
    "personagem": {
      "id": 1,
      "nome": "Aragorn"
    },
    "habilidade": {
      "id": 3,
      "nome": "Golpe Poderoso",
      "dano": 20
    }
  }
]
```

---

### Get All Skills
**Endpoint**: `GET /PersonagemHabilidades/GetHabilidades`

**Description**: Retrieves all available skills in the system.

**Response Example**:
```json
[
  {
    "id": 1,
    "nome": "Bola de Fogo",
    "dano": 25
  },
  {
    "id": 2,
    "nome": "Cura",
    "dano": -20
  }
]
```

---

### Remove Skill from Character
**Endpoint**: `POST /PersonagemHabilidades/DeletePersonagemHabilidade`

**Description**: Removes a skill from a character.

**Request Body**:
```json
{
  "personagemId": 1,
  "habilidadeId": 3
}
```

**Response**: Returns the removed skill-character relationship
```json
{
  "personagemId": 1,
  "habilidadeId": 3
}
```

---

## PersonagensExemplo (Example Characters)

**Note**: This controller uses in-memory data for demonstration purposes. Changes are not persisted.

### Get First Character
**Endpoint**: `GET /PersonagensExemplo/Get`

**Description**: Returns the first character from the example list.

---

### Get All Example Characters
**Endpoint**: `GET /PersonagensExemplo/GetAll`

**Description**: Returns all example characters.

---

### Get Single Example Character
**Endpoint**: `GET /PersonagensExemplo/{id}`

**Description**: Returns a single example character by ID.

**Parameters**:
- `id` (path, integer, required): Character ID

---

### Add Example Character
**Endpoint**: `POST /PersonagensExemplo`

**Description**: Adds a new character to the example list.

**Request Body**:
```json
{
  "id": 8,
  "nome": "Elrond",
  "pontosVida": 100,
  "forca": 19,
  "defesa": 20,
  "inteligencia": 36,
  "classe": 2
}
```

**Validation**:
- `inteligencia` must not be 0

---

### Get Characters Ordered by Strength
**Endpoint**: `GET /PersonagensExemplo/GetOrdenado`

**Description**: Returns characters ordered by strength (Forca).

---

### Get Character Count
**Endpoint**: `GET /PersonagensExemplo/GetContagem`

**Description**: Returns the total count of characters.

**Response Example**:
```json
"Quantidade de personagens: 7"
```

---

### Get Sum of Strength
**Endpoint**: `GET /PersonagensExemplo/GetSomaForca`

**Description**: Returns the sum of all characters' strength.

**Response Example**:
```json
144
```

---

### Get Characters Without Knights
**Endpoint**: `GET /PersonagensExemplo/GetSemCavaleiro`

**Description**: Returns characters excluding those with Cavaleiro (Knight) class.

---

### Get Characters by Approximate Name
**Endpoint**: `GET /PersonagensExemplo/GetByNomeAproximado/{nome}`

**Description**: Searches characters by partial name match.

**Parameters**:
- `nome` (path, string, required): Name or partial name to search

---

### Remove Mage Characters
**Endpoint**: `GET /PersonagensExemplo/GetRemovendoMago`

**Description**: Removes the first Mage character from the list.

**Response Example**:
```json
"Personagem removido: Gandalf"
```

---

### Get Characters by Strength Value
**Endpoint**: `GET /PersonagensExemplo/GetByForca/{forca}`

**Description**: Returns characters with a specific strength value.

**Parameters**:
- `forca` (path, integer, required): Strength value

---

### Update Example Character
**Endpoint**: `PUT /PersonagensExemplo`

**Description**: Updates an example character.

**Request Body**:
```json
{
  "id": 1,
  "nome": "Frodo Updated",
  "pontosVida": 95,
  "forca": 18,
  "defesa": 24,
  "inteligencia": 34,
  "classe": 1
}
```

---

### Delete Example Character
**Endpoint**: `DELETE /PersonagensExemplo/{id}`

**Description**: Deletes an example character by ID.

**Parameters**:
- `id` (path, integer, required): Character ID

---

### Get Characters by Class Enum
**Endpoint**: `GET /PersonagensExemplo/GetByEnum/{enumId}`

**Description**: Returns characters filtered by class enum.

**Parameters**:
- `enumId` (path, integer, required): Class enum value (1=Cavaleiro, 2=Mago, 3=Clerigo)

---

## PersonagensExercicio (Exercise Characters)

**Note**: This controller also uses in-memory data for practice exercises.

### Get All Exercise Characters
**Endpoint**: `GET /PersonagensExercicio/GetAll`

**Description**: Returns all exercise characters.

---

### Get Character by Name
**Endpoint**: `GET /PersonagensExercicio/GetByNome/{nome}`

**Description**: Returns a character by exact name match (case-insensitive).

**Parameters**:
- `nome` (path, string, required): Character name

---

### Create Character with Validation
**Endpoint**: `POST /PersonagensExercicio/PostValidacao`

**Description**: Creates a character with validation rules.

**Request Body**:
```json
{
  "nome": "Boromir",
  "pontosVida": 100,
  "forca": 22,
  "defesa": 15,
  "inteligencia": 31,
  "classe": 1
}
```

**Validation**:
- `defesa` must be greater than 10
- `inteligencia` must be greater than 30

---

### Create Mage with Validation
**Endpoint**: `POST /PersonagensExercicio/PostValidacaoMago`

**Description**: Creates a Mage character with intelligence validation.

**Request Body**:
```json
{
  "nome": "Saruman",
  "pontosVida": 100,
  "forca": 16,
  "defesa": 14,
  "inteligencia": 38,
  "classe": 2
}
```

**Validation**:
- If `classe` is Mago (2), `inteligencia` must be >= 35

---

### Get Clerics and Mages
**Endpoint**: `GET /PersonagensExercicio/GetClerigoMago`

**Description**: Removes all Knights and returns remaining characters ordered by health points (descending).

---

### Get Statistics
**Endpoint**: `GET /PersonagensExercicio/GetEstatisticas`

**Description**: Returns statistics about the characters.

**Response Example**:
```json
{
  "quantidadePersonagens": 7,
  "somatorioInteligencia": 235
}
```

---

### Get Characters by Class
**Endpoint**: `GET /PersonagensExercicio/GetByClasse/{idClasse}`

**Description**: Returns characters filtered by class ID.

**Parameters**:
- `idClasse` (path, integer, required): Class ID (1=Cavaleiro, 2=Mago, 3=Clerigo)

---

## Data Models

### Personagem (Character)
```json
{
  "id": 0,
  "nome": "string",
  "pontosVida": 0,
  "forca": 0,
  "defesa": 0,
  "inteligencia": 0,
  "classe": 0,
  "fotoPersonagem": "base64_string",
  "disputas": 0,
  "vitorias": 0,
  "derrotas": 0
}
```

### Arma (Weapon)
```json
{
  "id": 0,
  "nome": "string",
  "dano": 0,
  "personagemId": 0
}
```

### Usuario (User)
```json
{
  "id": 0,
  "username": "string",
  "passwordString": "string",
  "email": "string",
  "perfil": "string",
  "foto": "base64_string",
  "latitude": 0.0,
  "longitude": 0.0,
  "dataAcesso": "2023-10-15T10:30:00"
}
```

### Disputa (Battle)
```json
{
  "id": 0,
  "atacanteId": 0,
  "oponenteId": 0,
  "habilidadeId": 0,
  "narracao": "string",
  "dataDisputa": "2023-10-15T10:30:00",
  "listaIdPersonagens": [1, 2, 3],
  "resultados": ["string"]
}
```

### Habilidade (Skill)
```json
{
  "id": 0,
  "nome": "string",
  "dano": 0
}
```

### ClasseEnum (Class Enum)
- `1` = Cavaleiro (Knight)
- `2` = Mago (Mage)
- `3` = Clerigo (Cleric)

---

## Error Handling

All endpoints return errors in the following format:

**Status Code**: 400 Bad Request

**Response**:
```json
"Error message describing what went wrong"
```

Common error scenarios:
- Validation failures (e.g., health points > 100)
- Entity not found
- Business rule violations (e.g., character already has a weapon)
- Authentication failures

---

## Notes for Frontend Developers

1. **Authentication**: Store user information after successful authentication for subsequent requests.

2. **Image Handling**: Images (photos) are stored as base64-encoded strings. Convert images to base64 before sending to the API.

3. **Character Classes**: Use the ClasseEnum values (1, 2, or 3) when creating or updating characters.

4. **Battle System**: The battle endpoints automatically update character statistics (victories, defeats, disputes, and health points).

5. **In-Memory Controllers**: `PersonagensExemplo` and `PersonagensExercicio` controllers use in-memory data for demonstration and practice. Data is not persisted between application restarts.

6. **Pagination**: Currently, the API does not support pagination. All "GetAll" endpoints return complete lists.

7. **CORS**: Ensure CORS is properly configured on the server if calling from a browser-based frontend.

8. **Swagger/OpenAPI**: In development mode, you can access interactive API documentation at `/swagger`.

---

## Quick Start Example

### 1. Register a User
```javascript
const response = await fetch('https://your-api-domain.com/Usuarios/Registrar', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({
    username: 'player1',
    passwordString: 'securePassword',
    email: 'player1@example.com',
    perfil: 'Player'
  })
});
const userId = await response.json();
```

### 2. Authenticate User
```javascript
const response = await fetch('https://your-api-domain.com/Usuarios/Autenticar', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({
    username: 'player1',
    passwordString: 'securePassword'
  })
});
const user = await response.json();
```

### 3. Create a Character
```javascript
const response = await fetch('https://your-api-domain.com/Personagens', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({
    nome: 'Aragorn',
    pontosVida: 100,
    forca: 20,
    defesa: 18,
    inteligencia: 15,
    classe: 1
  })
});
const characterId = await response.json();
```

### 4. Create a Weapon
```javascript
const response = await fetch('https://your-api-domain.com/Armas', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({
    nome: 'Anduril',
    dano: 30,
    personagemId: characterId
  })
});
const weaponId = await response.json();
```

### 5. Get All Characters
```javascript
const response = await fetch('https://your-api-domain.com/Personagens/GetAll');
const characters = await response.json();
```

---

## Support

For questions or issues, please contact the development team or create an issue in the project repository.

**Last Updated**: 2023-10-15
