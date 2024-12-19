const apiUrl = 'https://localhost:7277/api/';
let loggedInUserRole = '';

// Fetch and display all users when the page loads
window.onload = fetchLoggedInUserRole;

// Fetch the logged-in user's role
function fetchLoggedInUserRole() {
    const loggedInUser = sessionStorage.getItem('loggedInUser');
    
    if (loggedInUser) {
        // Fetch all users to find the logged-in user's role
        fetch(`${apiUrl}User/GetAllUsers`)
            .then(response => response.json())
            .then(users => {
                const user = users.find(u => u.username === loggedInUser);
                
                if (user.roles == 3) {
                    loggedInUserRole = 3; // Assume roles is an array, e.g., [3] for Admin
                    console.log(`Logged-in user role: ${loggedInUserRole}`); // Log role for debugging
                }
                // After setting the role, fetch and display all users
                fetchUsers();
            })
            .catch(error => {
                showNotification(`Klaida gaunant vartotojo duomenis: ${error.message}`, 'error');
            });
    } else {
        // If no logged-in user, simply fetch users
        fetchUsers();
    }
}

// Fetch users from the API
function fetchUsers() {
    console.log('Fetching users...');
    fetch(`${apiUrl}User/GetAllUsers`)
        .then(response => response.json())
        .then(users => {
            console.log('Fetched users:', users);
            displayUsers(users);
        })
        .catch(error => {
            showNotification(`Klaida gaunant vartotojų duomenis: ${error.message}`, 'error');
        });
}

// Display all user cards
function displayUsers(users) {
    const body = document.body;

    // Add the title and logo to the body, before the user cards
    body.innerHTML = `
        <h1 class="title">Asmens Registravimo Sistema</h1>
        <div class="logo"><img src="ARSS_logo.jpg" alt="ARS Logo"></div>
        <div id="usersContainer" class="users-container"></div>
    `;

    const usersContainer = document.getElementById('usersContainer');
    const loggedInUser = sessionStorage.getItem('loggedInUser');

    if (loggedInUser) {
        displayLoggedInUser(loggedInUser);

        // Move the logged-in user to the beginning of the array
        const loggedInUserIndex = users.findIndex(user => user.username === loggedInUser);
        if (loggedInUserIndex !== -1) {
            const loggedInUserObj = users.splice(loggedInUserIndex, 1)[0]; // Remove the logged-in user from the array
            users.unshift(loggedInUserObj); // Add it to the beginning of the array
        }
    }

    users.forEach(user => displayUserCard(user, usersContainer));
}


function displayLoggedInUser(loggedInUser) {
    const body = document.querySelector('body');
    const userInfoContainer = document.createElement('div');
    userInfoContainer.classList.add('logged-in-user');

    userInfoContainer.innerHTML = `
        <span id="loggedInUser" style="color: #5c2d91; font-size: 12px;">Prisijungęs kaip: ${loggedInUser}</span>
        <button id="logoutButton">Atsijungti</button>
    `;

    body.insertBefore(userInfoContainer, body.firstChild);

    const logoutButton = document.getElementById('logoutButton');
    logoutButton.addEventListener('click', () => {
        sessionStorage.clear();
        window.location.href = 'index.html';
    });
}

function displayUserCard(user, container) {
    const userCard = document.createElement('div');
    userCard.classList.add('user-card');

    userCard.style.backgroundImage = `url(data:image/jpeg;base64,${user.generalInformation.giImage})`;

    const roleName = getRoleName(user.roles);

    const isLoggedInUser = sessionStorage.getItem('loggedInUser') === user.username;

    if (isLoggedInUser) {
        userCard.classList.add('logged-in-card');
    }

    userCard.innerHTML = `
        <div class="user-card-content">
            <h2 class="username ${isLoggedInUser ? 'logged-in-username' : ''}">${user.username}</h2>
            <p class="role">${roleName}</p>
        </div>
    `;

    userCard.addEventListener('dblclick', () => {
        enlargeUserCard(user, container);
    });

    container.appendChild(userCard);
}

function enlargeUserCard(user, container) {
    container.innerHTML = '';

    const userCard = document.createElement('div');
    userCard.classList.add('user-card', 'expanded');
    userCard.style.backgroundImage = `url(data:image/jpeg;base64,${user.generalInformation.giImage})`;

    const isOwnCard = sessionStorage.getItem('loggedInUser') === user.username;
    const isAdmin = loggedInUserRole === 3;

    userCard.innerHTML = `
        <div class="user-details">
            <h2>${user.username}</h2>
            <label>Vardas:</label>
            <input type="text" name="firstName" value="${user.generalInformation.firstName}" ${isOwnCard ? '' : 'disabled'}>
            
            <label>Pavardė:</label>
            <input type="text" name="lastName" value="${user.generalInformation.lastName}" ${isOwnCard ? '' : 'disabled'}>
            
            <label>Tel. numeris:</label>
            <input type="text" name="phoneNumber" value="${user.generalInformation.phoneNumber}" ${isOwnCard ? '' : 'disabled'}>

            <label>Asmens kodas:</label>
            <input type="text" name="personalCode" value="${user.generalInformation.personalCode}" ${isOwnCard ? '' : 'disabled'}>

            <label>El. paštas:</label>
            <input type="text" name="email" value="${user.generalInformation.email}" ${isOwnCard ? '' : 'disabled'}>
            
            <label>Adresas:</label>
            <input type="text" name="town" value="${user.generalInformation.giAddress.town}" ${isOwnCard ? '' : 'disabled'}>
            <input type="text" name="street" value="${user.generalInformation.giAddress.street}" ${isOwnCard ? '' : 'disabled'}>
            <input type="text" name="houseNumber" value="${user.generalInformation.giAddress.houseNumber}" ${isOwnCard ? '' : 'disabled'}>
            <input type="text" name="apartmentNumber" value="${user.generalInformation.giAddress.apartmentNumber}" ${isOwnCard ? '' : 'disabled'}>
            
            <div class="button-group">
                <button id="okButton">OK</button>
                <button id="cancelButton">Atšaukti</button>
                ${isAdmin ? '<button id="deleteButton">Ištrinti</button>' : ''}
            </div>
        </div>
    `;

    document.body.appendChild(userCard);

    userCard.querySelector('#okButton').addEventListener('click', async () => {
        if (isOwnCard) {
            try {
                const updatedUserInfo = {
                    firstName: userCard.querySelector('input[name="firstName"]').value,
                    lastName: userCard.querySelector('input[name="lastName"]').value,
                    phoneNumber: userCard.querySelector('input[name="phoneNumber"]').value,
                    personalCode: userCard.querySelector('input[name="personalCode"]').value,
                    email: userCard.querySelector('input[name="email"]').value,
                    address: {
                        town: userCard.querySelector('input[name="town"]').value,
                        street: userCard.querySelector('input[name="street"]').value,
                        houseNumber: userCard.querySelector('input[name="houseNumber"]').value,
                        apartmentNumber: userCard.querySelector('input[name="apartmentNumber"]').value
                    }
                };

                await updateField('FirstName', updatedUserInfo.firstName);
                await updateField('LastName', updatedUserInfo.lastName);
                await updateField('PhoneNumber', updatedUserInfo.phoneNumber);
                await updateField('PersonalCode', updatedUserInfo.personalCode);
                await updateField('Email', updatedUserInfo.email);

                await updateAddressField(user.id, 'Town', updatedUserInfo.address.town);
                await updateAddressField(user.id, 'Street', updatedUserInfo.address.street);
                await updateAddressField(user.id, 'HouseNumber', updatedUserInfo.address.houseNumber);
                await updateAddressField(user.id, 'ApartmentNumber', updatedUserInfo.address.apartmentNumber);

                showNotification('Informacija sėkmingai išsaugota!', 'success');
            } catch (error) {
                showNotification('Klaida atnaujinant informaciją.', 'error');
            }
        } else {
            showNotification('Neturite teisės redaguoti šios informacijos.', 'error');
        }
    });

    userCard.querySelector('#cancelButton').addEventListener('click', resetView);

    if (isAdmin) {
        userCard.querySelector('#deleteButton').addEventListener('click', async () => {
            const confirmation = confirm("Ar tikrai norite ištrinti šį vartotoją?");
            if (confirmation) {
                await deleteUser(user.id);
                resetView();
            }
        });
    }
}

async function updateField(field, value) {
    const response = await fetch(`https://localhost:7277/api/GeneralInformation/${user.id}/${field}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${sessionStorage.getItem('jwtToken')}`,
        },
        body: JSON.stringify(value),
    });

    if (!response.ok) {
        throw new Error(`Failed to update ${field}`);
    }
}

async function updateAddressField(userId, field, value) {
    const response = await fetch(`https://localhost:7277/api/Address/${userId}/${field}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${sessionStorage.getItem('jwtToken')}`,
        },
        body: JSON.stringify(value),
    });

    if (!response.ok) {
        throw new Error(`Failed to update ${field}`);
    }
}

async function deleteUser(userId) {
    const response = await fetch(`https://localhost:7277/api/User/Delete/${userId}`, {
        method: 'DELETE',
        headers: {
            'Authorization': `Bearer ${sessionStorage.getItem('jwtToken')}`,
        }
    });

    if (response.ok) {
        showNotification('Vartotojas buvo ištrintas!', 'success');
    } else {
        showNotification('Klaida šalinant vartotoją.', 'error');
    }
}

function resetView() {
    console.log('Reset the view to the default user card');
}

function showNotification(message, type) {
    console.log(`${type.toUpperCase()}: ${message}`);
}

function deleteUser(username) {
    fetch(`${apiUrl}User/${username}`, {
        method: 'DELETE',
        headers: {
            'Authorization': `Bearer ${sessionStorage.getItem('jwtToken')}`
        }
    })
    .then(response => {
        if (response.ok) {
            showNotification('Vartotojas sėkmingai ištrintas!', 'success');
            resetView();
        } else {
            showNotification('Klaida trinant vartotoją.', 'error');
        }
    })
    .catch(error => {
        showNotification(`Klaida trinant vartotoją: ${error.message}`, 'error');
    });
}

function resetView() {
    document.body.innerHTML = '';
    fetchUsers();
}

function getRoleName(roleId) {
    switch (roleId) {
        case 1: return 'Narys';
        case 2: return 'Moderatorius';
        case 3: return 'Administratorius';
        case 4: return 'Svečias';
        default: return 'Nežinomas vaidmuo';
    }
}

function showNotification(message, type) {
    let notification = document.getElementById('notification');

    if (!notification) {
        notification = document.createElement('div');
        notification.id = 'notification';
        document.body.appendChild(notification);
    }

    notification.textContent = message;
    notification.className = `notification ${type}`;
    notification.style.display = 'block';

    setTimeout(() => {
        notification.style.display = 'none';
    }, 2000);
}
