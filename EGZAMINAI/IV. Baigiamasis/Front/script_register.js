let steps;
let currentStep = 1;

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
    document.querySelector(".logo").addEventListener('click', function() {
        window.location.assign('index.html');
    });
}

const registerUserFormFiller = () => {
    const userFormSection = document.createElement("section");
    userFormSection.classList.add("user-section");

    userFormSection.innerHTML = `
    <div class="user-form">
            <form class="userform">
            <label class="username">Naujas prisijungimo vardas: </label>
            <br>
            <input class="usernameInput" type="text" required>
            <br>
            <label class="password">Naujas slaptažodis: </label>
            <br>
            <input class="passwordInput" type="password" required>
            <br>
        </form>
    </div>
    `;
    document.body.append(userFormSection);
}

const registerGIFormFiller = () => {
    const formSection = document.createElement("section");
    formSection.classList.add("form-section");
    formSection.innerHTML = `
    <div class="GI-form">
        <form class="giform">
            <label class="firstname">Vardas: </label><br>
            <input class="firstnameInput" type="text" required><br>        
            <label class="lastname">Pavardė: </label><br>
            <input class="lastnameInput" type="text" required><br>       
            <label class="personalcode">Asmens kodas: </label><br>
            <input class="personalcodeInput" type="number" required><br> 
            <label class="phonenumber">Telefono nr.: </label><br>
            <input class="phonenumberInput" type="tel" required><br>
            <label class="email">El. paštas: </label><br>
            <input class="emailInput" type="email" required><br>
            <label class="photo">Nuotrauka: </label><br>
            <input class="photoInput" type="file" required><br>
            </form>
    </div>
    `;
    document.body.append(formSection);
}

const registerAddressFormFiller = () => {
    const addressSection = document.createElement("section");
    addressSection.classList.add("address-section");
    addressSection.innerHTML = `
    <div class="address-form">
        <form class="addressform">
        <label class="town">Miestas: </label><br>
        <input class="townInput" type="text" required><br>
        <label class="street">Gatvė: </label><br>
        <input class="streetInput" type="text" required><br>
        <label class="housenumber">Namo nr.: </label><br>
        <input class="housenumberInput" type="text" required><br>
        <label class="apartmentnumber">Buto nr.: </label><br>
        <input class="apartmentnumberInput" type="number" required><br>
        </form>
    </div>
    `;
    document.body.append(addressSection);
}

const inputInformationCheck = () => {
    const summarySection = document.createElement("section");
    summarySection.classList.add("summary-section");

    const username = document.querySelector(".usernameInput").value;
    const password = document.querySelector(".passwordInput").value;
    const firstname = document.querySelector(".firstnameInput").value;
    const lastname = document.querySelector(".lastnameInput").value;
    const personalcode = document.querySelector(".personalcodeInput").value;
    const phonenumber = document.querySelector(".phonenumberInput").value;
    const email = document.querySelector(".emailInput").value;
    const town = document.querySelector(".townInput").value;
    const street = document.querySelector(".streetInput").value;
    const housenumber = document.querySelector(".housenumberInput").value;
    const apartmentnumber = document.querySelector(".apartmentnumberInput").value;

    summarySection.innerHTML = `
        <h3>Peržiūrėti ir patvirtinti informaciją</h3>
        <div class="summary-content">
            <p><strong>Prisijungimo vardas:</strong> ${username}</p>
            <p><strong>Slaptažodis:</strong> ${password}</p>
            <p><strong>Vardas:</strong> ${firstname}</p>
            <p><strong>Pavardė:</strong> ${lastname}</p>
            <p><strong>Asmens kodas:</strong> ${personalcode}</p>
            <p><strong>Telefono nr.:</strong> ${phonenumber}</p>
            <p><strong>El. paštas:</strong> ${email}</p>
            <p><strong>Miestas:</strong> ${town}</p>
            <p><strong>Gatvė:</strong> ${street}</p>
            <p><strong>Namo nr.:</strong> ${housenumber}</p>
            <p><strong>Buto nr.:</strong> ${apartmentnumber}</p>
        </div>
    `;

    document.body.append(summarySection);
}

const showSubmitButtons = () => {
    const buttonsSection = document.createElement("section");
    buttonsSection.classList.add("buttons-section");
    buttonsSection.innerHTML = `
    <form class="submit-form">
        <button class="submit" type="submit">Pateikti</button>
        <button class="cancel" type="button">Atšaukti</button>
    </form>
    `;
    document.body.append(buttonsSection);

    document.querySelector(".submit-form").addEventListener("submit", (e) => {
        e.preventDefault(); // Prevent default form submission
        submitFormData();   // Call your submission function
    });

    document.querySelector(".cancel").addEventListener('click', function () {
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

    steps = document.querySelectorAll(".step");
    updateProgress();
}

const updateProgress = () => {
    steps.forEach((step, index) => {
        step.classList.toggle("active", index < currentStep);
    });
    showCurrentForm();
}

const showCurrentForm = () => {

    document.querySelectorAll(".user-section, .form-section, .address-section, .buttons-section, .summary-section")
        .forEach(section => section.style.display = 'none');

    if (currentStep === 1) {
        document.querySelector(".user-section").style.display = 'block';
    } else if (currentStep === 2) {
        document.querySelector(".form-section").style.display = 'block';
    } else if (currentStep === 3) {
        document.querySelector(".address-section").style.display = 'block';
    }
    else if (currentStep === 4) {
        // Hide the progress bar and form sections
        document.querySelector(".progress-line-section").style.display = 'none';
        document.querySelector(".user-section").style.display = 'none';
        document.querySelector(".form-section").style.display = 'none';
        document.querySelector(".address-section").style.display = 'none';
    
        // Generate the summary content first
        inputInformationCheck();
    
        // Then show the submit buttons after the summary content is added
        showSubmitButtons();
    
        // Display the submit buttons section and hide the progress buttons
        document.querySelector(".buttons-section").style.display = 'block';
        document.querySelector(".proceed").style.display = 'none';
        document.querySelector(".back").style.display = 'none';
    }
}

const collectFormData = () => {
    return {
        username: document.querySelector(".usernameInput").value,
        password: document.querySelector(".passwordInput").value,
        firstname: document.querySelector(".firstnameInput").value,
        lastname: document.querySelector(".lastnameInput").value,
        personalcode: document.querySelector(".personalcodeInput").value,
        phonenumber: document.querySelector(".phonenumberInput").value,
        email: document.querySelector(".emailInput").value,
        town: document.querySelector(".townInput").value,
        street: document.querySelector(".streetInput").value,
        housenumber: document.querySelector(".housenumberInput").value,
        apartmentnumber: document.querySelector(".apartmentnumberInput").value,
        photo: document.querySelector(".photoInput").files[0]
    };
}

const submitFormData = async () => {
    const formData = collectFormData();

    // Create FormData object to handle file uploads (e.g., photo)
    const data = new FormData();
    data.append("username", formData.username);
    data.append("password", formData.password);
    data.append("firstname", formData.firstname);
    data.append("lastname", formData.lastname);
    data.append("personalcode", formData.personalcode);
    data.append("phonenumber", formData.phonenumber);
    data.append("email", formData.email);
    data.append("town", formData.town);
    data.append("street", formData.street);
    data.append("housenumber", formData.housenumber);
    data.append("apartmentnumber", formData.apartmentnumber);
    data.append("GIImage", formData.photo);

    try {
        const response = await fetch('https://localhost:7277/api/User/SignUp', {
            method: 'POST',
            body: data,
        });

        if (response.ok) {
            const userId = await response.text();
            alert(`Vartotojas sėkmingai sukurtas. Vartotojo ID: ${userId}`);
                window.location.href = 'login.html';
        } else {
            const errorText = await response.text();
            console.error('Klaidos kodas:', errorText);
            alert(`Klaida registruojant vartotoją: ${errorText || response.statusText}`);
        }
    } catch (error) {
        console.error('Error:', error);
        alert('Įvyko nenumatyta klaida!');
    }
};

showLogo();
registerUserFormFiller();
registerGIFormFiller();
registerAddressFormFiller();
inputInformationCheck();
showSubmitButtons();
progressController();
showProgressButtons();
