document.addEventListener("DOMContentLoaded", function () {
    const toggleBtn = document.createElement("div");
    toggleBtn.id = "chatbot-toggle";
    toggleBtn.innerHTML = "✈️";
    document.body.appendChild(toggleBtn);

    const chatbox = document.createElement("div");
    chatbox.id = "chatbot-container";
    chatbox.style.display = "none";
    chatbox.innerHTML = `
        <div id="chatbot-box">
            <div id="chatbot-header">Hỗ trợ LTIA ✈️</div>
            <div id="chatbot-messages"></div>
            <div id="chatbot-input-area">
                <input type="text" id="chatbot-input" placeholder="Nhập câu hỏi..." />
                <button id="chatbot-send">Gửi</button>
            </div>
        </div>
    `;
    document.body.appendChild(chatbox);

    toggleBtn.onclick = () => {
        chatbox.style.display = chatbox.style.display === "none" ? "block" : "none";
    };

    const input = document.getElementById("chatbot-input");
    const sendBtn = document.getElementById("chatbot-send");
    const messages = document.getElementById("chatbot-messages");

    function addMessage(from, text) {
        const msg = document.createElement("div");
        msg.className = "message " + from;
        msg.textContent = text;
        messages.appendChild(msg);
        messages.scrollTop = messages.scrollHeight;
    }

    sendBtn.addEventListener("click", async () => {
        const text = input.value.trim();
        if (!text) return;
        addMessage("user", text);
        input.value = "";

        const res = await fetch("/api/chat", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ message: text })
        });
        const data = await res.json();
        addMessage("bot", data.reply);
    });
});
