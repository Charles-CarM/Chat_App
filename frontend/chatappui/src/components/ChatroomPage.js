import React, { useEffect, useState } from "react"
import { HubConnectionBuilder } from "@microsoft/signalr"
//import {Link} from 'react-router-dom'
import "../styling/ChatroomPage.css"
import axios from "axios"

function ChatroomPage() {
  const [message, setMessage] = useState("")
  const [chatroom, setChatroom] = useState([])
  const [hubConnection, setHubConnection] = useState(null)

  const baseUrl = process.env.BASE_URL

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl(`${baseUrl}/chatHub`, { withCredentials: true })
      //.withUrl(`/chatHub`)
      .withAutomaticReconnect()
      .build()

    setHubConnection(connection)

    connection
      .start()
      .catch((error) => {
        console.log("connection failed", error)
      })
      .then(() => {
        console.log("Websocket connection successful")

        connection.on("ReceiveMessage", (user, message) => {
          console.log(`${user} sent message: ${message}`)
        })
      })

    return () => {
      if (hubConnection) {
        hubConnection.stop()
      }
    }
  }, [])

  useEffect(() => {
    const getChatroomFeed = async () => {
      const response = await axios.get(`${baseUrl}/chatHub/api/messages`)
      const requestChatroom = response.data

      const updatedChatroom = requestChatroom.map((user) => {
        return {
          id: user.id,
          username: user.username,
          messages: [],
        }
      })
      setChatroom(updatedChatroom)
    }

    getChatroomFeed()
  }, [])

  // const updatedUsers = users.map((user) => {
  //   if (user.name === "Current User") {
  //     return {
  //       ...user,
  //       messages: [...user.messages, newMessage],
  //     }
  //   }
  //   return user
  // })

  // const updatedUsers = users.map((user) => {
  //   if (user.username) {
  //     return {
  //       ...user,
  //       messages: [...user.messages, newMessage],
  //     }
  //   }
  //   return user

  //setUsers(updatedUsers)
  //only after a successful post
  //setMessage("")

  async function handleSendMessage(event) {
    event.preventDefault()

    if (!message.trim()) {
      return
    }

    try {
      const response = await axios.post(`${baseUrl}/chatHub/api/messages}`, {
        text: message,
      })

      const newMessage = response.data

      setChatroom((prevChatroom) => [...prevChatroom, newMessage])
      setMessage("")
    } catch (err) {
      console.log(err)
    }
  }

  const renderMessage = chatroom.flatMap((user) => {
    return user.messages.map((message) => (
      <li className="create--message" key={message.id}>
        <span className="username">{user.username}</span>
        <span className="content">{message.message}</span>
      </li>
    ))
  })

  return (
    <div className="chatroomPage--container">
      <span className="active--users">
        <h2>Active Now</h2>
        <ul>
          <li>User A</li>
          <li>User B</li>
          <li>User C</li>
          <li>User D</li>
        </ul>
      </span>

      <span className="chatroom">
        <ul className="message--container">{renderMessage}</ul>
      </span>

      <form className="input--container" onSubmit={handleSendMessage}>
        <input
          type="text"
          placeholder="...enter message here"
          value={message}
          onChange={(e) => setMessage(e.target.value)}
        />
        <button className="submit--message">Send</button>
      </form>

      {/* // const sendMessage = async (message) => {
  //   if (hubConnection && user && message) {
  //     //if (hubConnection && username && message) {
  //     try {
  //       await hubConnection.invoke("SendMessage", user, message)
  //     } catch (error) {
  //       console.log(error)
  //     }
  //   }
  // } */}
    </div>
  )
}

export default ChatroomPage
