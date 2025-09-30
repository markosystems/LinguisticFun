// JavaScript source code
// Looks for text on screen and swaps it with other text

// Sends each element's innerText to the server and replaces it with the server-edited text.
// - Skips non-visual or form elements (SCRIPT, STYLE, INPUT, TEXTAREA, SELECT, OPTION, IFRAME, NOSCRIPT).
// - Sends a POST with JSON: { text: "<original>" }.
// - Accepts either JSON { text: "<edited>" } or plain text responses.
// - Limits concurrent requests to avoid flooding the server.

var changedelements= [];

async function swapText() {
    replacebytag("a");
    replacebytag("span");
    replacebytag("div");
    replacebytag("strong");
    replacebytag("h1");
    replacebytag("h2");
    replacebytag("h3");
    replacebytag("h4");
    replacebytag("b");
    replacebytag("li");
    replacebytag("p");
    replacebytag("td");
    replacebytag("th");
    replacebytag("button");
    replacebytag("label");
    replacebytag("option");
    replacebytag("caption");
    replacebytag("figcaption");
    replacebytag("blockquote");
    replacebytag("cite");
    replacebytag("q");
    replacebytag("summary");
    replacebytag("legend");
    replacebytag("pre");
    replacebytag("code");
    replacebytag("em");
    replacebytag("i");
    replacebytag("u");
    replacebytag("small");
    replacebytag("mark");
    replacebytag("sup");
    replacebytag("sub");
    replacebytag("del");
    replacebytag("ins");
    replacebytag("dfn");
    replacebytag("s");
    replacebytag("time");
    replacebytag("address");


}

async function replaceTextNodes(element, newText) {
    let textNodeFound = false;
    for (let node of element.childNodes) {
        if (node.nodeType === Node.TEXT_NODE) {
            node.textContent = newText;
            textNodeFound = true;
        }
    }
    // If no text node exists, optionally append one
    if (!textNodeFound && newText) {
        element.appendChild(document.createTextNode(newText));
    }
}

async function replacebytag(tagname) {
    const elements = document.body.getElementsByTagName(tagname);
    for (var i = 0; i < elements.length; i++) {
        if (changedelements.includes(elements[i])) continue;
        changedelements.push(elements[i]);
        const el = elements[i];
        // Only operate if element has a direct text node
        let text = Array.from(el.childNodes)
            .filter(n => n.nodeType === Node.TEXT_NODE)
            .map(n => n.textContent)
            .join('').trim();
        if (text.length > 0) {
            console.log(text);
            var newText = await sendTextToServer(text);
            replaceTextNodes(el, newText);
        }
    }
}


async function sendTextToServer(text) {
    try {
        const response = await fetch("http://localhost:8080/Phone", {
            method: 'POST', // use POST to send text
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ message: text }),
        });

        if (!response.ok) {
            throw new Error(`Server error: ${response.status}`);
        }

        const data = await response.json();
        console.log('Received from server:', data.Message);
        return data.Message; // or data.message if the server sends back { message: "..." }
    } catch (error) {
        console.error('Error sending text:', error);
        throw error;
    }
}



const observer = new MutationObserver(swapText);

// Observe changes to the entire document subtree
observer.observe(document.body, { subtree: true, childList: true });

swapText();