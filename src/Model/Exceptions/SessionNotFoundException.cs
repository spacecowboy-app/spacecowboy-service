﻿/*
    Copyright 2021-2025 Rolf Michelsen and Tami Weiss

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

        http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/

using System;


namespace Spacecowboy.Service.Model.Exceptions
{
    /// <summary>
    /// Exception thrown when trying to retrieve a session that does not exist
    /// </summary>
    public class SessionNotFoundException : Exception
    {
        /// <summary>
        /// Create exception to signal that a session does not exist
        /// </summary>
        /// <param name="sessionId">Session identifier</param>
        public SessionNotFoundException(string sessionId) : base($"Session {sessionId} does not exist") { }

    }
}
