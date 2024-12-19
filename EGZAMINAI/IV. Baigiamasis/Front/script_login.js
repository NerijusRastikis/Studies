const showLogo = () => {
    const logoSection = document.createElement("section");
    logoSection.classList.add("logo-section");

    logoSection.innerHTML = `
        <div class="index-logo">
            <h1 class="title">Asmens Registravimo Sistema</h1>
            <div class="image-container">
                <img src="https://i.ibb.co/2KN9cBs/ARSS-Logo.jpg" alt="Logo" class="logo">
            </div>
            <br>
        </div>
    `;
    document.body.append(logoSection);
}

const showLoginButtons = () => {
    const loginButtonsSection = document.createElement("section");
    loginButtonsSection.classList.add("login-buttons-section");

    loginButtonsSection.innerHTML = `
        <div class="login-buttons">
            <label class="prisijungti-label">Prisijungimo vardas: </label><br>
            <input type="text" class="username-input"><br>
            <label class="prisijungti-label">Slaptažodis: </label><br>
            <input type="password" class="password-input"><br>
            <button class="Prisijungti">Prisijungti</button>
            <button class="Atgal">Atgal</button>
        </div>
    `;

    document.body.append(loginButtonsSection);

    document.querySelector(".Atgal").addEventListener('click', function() {
        window.location.assign('index.html');
    });

    document.querySelector('.Prisijungti').addEventListener('click', function() {
        const username = document.querySelector('.username-input').value;
        const password = document.querySelector('.password-input').value;

        const userData = {
            username: username,
            password: password
        };

        fetch('https://localhost:7277/api/User/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(userData),
        })
        .then(response => response.text())
        .then(token => {
            if (token.length > 49) {
                sessionStorage.setItem('jwtToken', token);
                sessionStorage.setItem("loggedInUser", username);
                window.location.assign('ARS.html');
            } else {
                alert('Neteisingas prisijungimo vardas arba slaptažodis.');
            }
        })
        .catch(error => {
            console.error('Error during login:', error);
            alert('An error occurred, please try again later.');
        });
    });
}

showLogo();
showLoginButtons();
