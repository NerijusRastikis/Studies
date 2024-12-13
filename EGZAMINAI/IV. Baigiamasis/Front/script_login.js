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
            <label class="prisijungti-label">Username: </label>
            <input type="text" class = "username-input">
            <br>
            <label class="prisijungti-label">Password: </label>
            <input type="text" class = "password-input">
            <br>
            <button class="Prisijungti">Prisijungti</button>
            <button class="Atgal">Atgal</button>
        </div>
    `;
    document.body.append(logoSection);
    document.querySelector(".Atgal").addEventListener('click', function() {
        window.location.assign('index.html');
    });
    document.querySelector('.Prisijungti').addEventListener('click', function() {
        window.location.assign('login.html');
    });
}
showLogo();