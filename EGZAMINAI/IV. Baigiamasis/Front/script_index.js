const showLogo = () => {
    sessionStorage.clear();
    const logoSection = document.createElement("section");
    logoSection.classList.add("logo-section");

    logoSection.innerHTML = `
        <div class="index-logo">
            <h1 class="title">Asmens Registravimo Sistema</h1>
            <div class="image-container">
                <img src="https://i.ibb.co/2KN9cBs/ARSS-Logo.jpg" alt="Logo" class="logo">
            </div>
            <br>
            <button class="Prisijungti">Prisijungti</button>
            <button class="Registruotis">Registruotis</button>
        </div>
    `;
    document.body.append(logoSection);
    document.querySelector(".Registruotis").addEventListener('click', function() {
        window.location.assign('register.html');
    });
    document.querySelector('.Prisijungti').addEventListener('click', function() {
        window.location.assign('login.html');
    });
}
showLogo();