const showLogo = () => {
    const logoSection = document.createElement("section");
    logoSection.classList.add("logo-section");

    logoSection.innerHTML = `
        <div class="index-logo">
            <img src="https://i.ibb.co/2KN9cBs/ARSS-Logo.jpg" alt="Logo" class="logo">
            <br>
            <h2 class="title">Registracija</h2>
            <br>
        </div>
    `;
    document.body.append(logoSection);
}
const registerUserFormFiller = () => {
    const userFormSection = document.createElement("section");
    userFormSection.classList.add("user-section");

    userFormSection.innerHTML = `
    <div class="user-form">
        <label class="username">Prisijungimo vardas: </label>
        <br>
        <input class="usernameInput" type="text" required>
        <br>
        <label class="password">Slaptazodis: </label>
        <br>
        <input class="passwordInput" type="password" required>
        <br>
    </div>
    `;
    document.body.append(userFormSection);
}
const registerGIFormFiller = () => {
    const formSection = document.createElement("section");
    formSection.classList.add("form-section");

    formSection.innerHTML = `
    <div class="register-form">
    <h1 class="general-info">Asmens duomenys</h1>
    <label class="firstname">Vardas: </label>
    <br>
    <input class="firstnameInput" type="text" required>
    <br>
    <label class="lastname">Pavardė: </label>
    <br>
    <input class="lastnameInput" type="text" required>
    <br>
    <label class="personalcode">Asmens kodas: </label>
    <br>
    <input class="personalcodeInput" type="number" required>
    <br>
    <label class="email">El. paštas: </label>
    <br>
    <input class="emailInput" type="email" required>
    <br>
    <label class="phonenumber">Telefono nr.: </label>
    <br>
    <input class="phonenumberInput" type="text" required>
    <br>
    <label class="image">Nuotrauka: </label>
    <br>
    <input class="imageInput" type="file" accepts="image/jpg">
    </div>
    `;
    document.body.append(formSection);
}
const registerAddressFormFiller = () => {
    const addressSection = document.createElement("section");
    addressSection.classList.add("address-section");

    addressSection.innerHTML = `
    <h1 class="address-title">Adresas</h1>
    <label class="town">Miestas: </label>
    <br>
    <input class="townInput" type="text" required>
    <br>
    <label class="street">Gatvė: </label>
    <br>
    <input class="streetInput" type="text" required>
    <br>
    <label class="housenumber">Namo nr.: </label>
    <br>
    <input class="housenumberInput" type="text" required>
    <br>
    <label class="apartmentnumber">Buto nr.: </label>
    <br>
    <input class="apartmentnumberInput" type="number" required>
    `;
    document.body.append(addressSection);
}
const showSubmitButtons = () => {
    const buttonsSection = document.createElement("section");
    buttonsSection.classList.add("buttons-section");
    buttonsSection.innerHTML = `
    <button class="submit">Pateikti</button>
    <button class="cancel">Atšaukti</button>
    `;
    document.body.append(buttonsSection);
    document.querySelector('.submit').addEventListener('click', function() {
        window.location.assign('login.html');
    });
        document.querySelector('.cancel').addEventListener('click', function() {
            window.location.assign('index.html');
    });
}
const showProgressButtons = () => {
    const progressBtnsSection = document.createElement("section");
    progressBtnsSection.classList.add("progress-btns-section");
    progressBtnsSection.innerHTML = `
        <button class="proceed">Tęsti</button>
        <button class="back" disabled>Grįžti</button>
    `;
    document.body.append(progressBtnsSection);

    const proceedBtn = document.querySelector(".proceed");
    const backBtn = document.querySelector(".back");

    proceedBtn.addEventListener("click", () => {
        if (currentStep < steps.length) {
            currentStep++;
            updateProgress();
            backBtn.disabled = false;
            if (currentStep === steps.length) proceedBtn.disabled = true;
        }
    });
    backBtn.addEventListener("click", () => {
        if (currentStep > 1) {
            currentStep--;
            updateProgress();
            proceedBtn.disabled = false;
            if (currentStep === 1) backBtn.disabled = true;
        }
    });
};
const progressController = () => {
    const progressLineSection = document.createElement("section");
    progressLineSection.classList.add("progress-line-section");
    progressLineSection.innerHTML = `
    <div class="progress-container">
        <div class="progress-bar">
            <div class="progress-line"></div>
            <div class="step active" data-step="1">1</div>
            <div class="step" data-step="2">2</div>
            <div class="step" data-step="3">3</div>
            <div class="step" data-step="4">4</div>
        </div>
    </div>
    `;
    document.body.append(progressLineSection);

    const steps = document.querySelectorAll(".step");
    let currentStep = 1;

    const updateProgress = () => {
        steps.forEach((step, index) => {
            if (index < currentStep) {
                step.classList.add("active");
            } else {
                step.classList.remove("active");
            }
        });

        const progressPercentage = ((currentStep - 1) / (steps.length - 1)) * 100;
        document.querySelector(".progress-line").style.setProperty('--progress-width', `${progressPercentage}%`);
    };

    updateProgress();
};

progressController();
showLogo();
registerGIFormFiller();
registerAddressFormFiller();
showSubmitButtons();
showProgressButtons();
updateProgress();