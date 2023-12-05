function getTeam() {
    let team = undefined;
    let players = [];
    fetch('https://localhost:44359/teams/3b83dd1c-9539-4387-93d2-b6a0632f97ef', {
        headers: {
            "Content-Type": "application/json"
        }
    }).then(res => res.json())
    .then(t => {
        team = t
        if(team !== undefined) {
            fetch('https://localhost:44359/teams/3b83dd1c-9539-4387-93d2-b6a0632f97ef/players', {
                headers: {
                    "Content-Type": "application/json"
                }
            }).then(res => res.json())
            .then(p => {
                players = p
            });
        }
    });

    

    console.log(team)
    console.log(players)
}