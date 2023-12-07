```mermaid
    erDiagram
    ROLE { }
    GENDER { }
    POST { }
    TICKET_PASS { }
    USER {
        string id
        string name
        string email
        string password
    }
    PLAYER_DETAILS {
        string id
        string userId
        Date birthday
        string phone
        number playerNumber
    } 
    TEAM {
        string id
        string name
        string picture
        string description
    }
    TRAINING {
        string id
        string location
        Date date
        string description
    }
    TOURNAMENT {
        string id
        Date date
        string description 
        string location
    }
    USER ||--o| PLAYER_DETAILS : references
    TEAM }|--|{ PLAYER_DETAILS : has
    TEAM ||--o{ TRAINING : participates
    USER }o--|{ ROLE: has
    PLAYER_DETAILS }o--|| TICKET_PASS: has
    PLAYER_DETAILS }|--|{ POST: has
    PLAYER_DETAILS }o--|| GENDER: has
    TEAM }o--|{ USER : coached_by
    TRAINING }o--|{ USER : participants
    TOURNAMENT }o--|{ TEAM : competitors
```

## Description
--o| nullable field \
--|| not nullable field \
--o{ list \
--|{ list \
}o--o{ linking table \
}|--o{ linking table

Use-cases:
- User:
    - can register 
    - can add own player details
    - nice-to-have: 
        - feedback for training
        - can request to join a team
        - respond to training
- Coach:
    - can add team member
    - can add trainings
- Administrator:
    - can create new team
    - can create new tournament
    - can assign coach to team
    - can promote a user to a coach
    - temporary
        - can add team member
        - can add trainings
        - can add details for a player


