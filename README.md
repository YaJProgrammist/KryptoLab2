# KryptoLab2
<b>Theoretical part:</b><br>
The one time pad (OTP) is a type of stream cipher that is a secure method of encryption. It’s simple to implement and is secure as long as the length of the key is greater than or equal to the length of the message. That’s its major downfall. However, it also requires that the key never be used more than once. This laboratory work shows what happens when you re-use a key to encrypt more than one message. <br>
We will use a method called crib dragging to uncover the plain-text of two messages that have been encrypted with the same key, without even knowing the key. <br>
<br>
Say we send messages A and B of the same length, both encrypted using same key, K. The stream cipher produces a string of bits C(K) the same length as the messages. The encrypted versions of the messages then are:<br>
<br>
E(A) = A xor C<br>
E(B) = B xor C<br>
where xor is performed bit by bit.<br>
Say an adversary has intercepted E(A) and E(B). He can easily compute: <br>
E(A) xor E(B)<br>
However, xor is commutative and has the property that X xor X = 0 (self-inverse) so:
E(A) xor E(B) = (A xor C) xor (B xor C) = A xor B xor C xor C = A xor B<br>
E(A) xor E(B)<br>
However, xor is commutative and has the property that X xor X = 0 (self-inverse) so:<br>
<br>
E(A) xor E(B) = (A xor C) xor (B xor C) = A xor B xor C xor C = A xor B
<br>
That means, if A and B were encrypted using the same key, we can decrypt A xor B

<b>Algorithm by example:</b><br>
Input : <br>
Using first two quotes from https://docs.google.com/document/d/19vgZtvDN4_StEgVEM9MjfxnqfayByLNMD7PFJgvZv7c/edit <br>
![ciphertext.jpg](https://github.com/YaJProgrammist/KryptoLab2/blob/main/Screenshots/ciphertext.jpg?raw=true)<br>

1) Guess a word that might appear in one of the messages <br>
For this point we might check https://en.wikipedia.org/wiki/Most_common_words_in_English <br>
First time we'll be use the most popular word "the"

2) Encode the word from step 1 to a hex string <br>

3) XOR the two cipher-text messages <br>

4) XOR the hex string from step 2 at each position of the XOR of the two cipher-texts (from step 3) <br>
![q1q2XORcribword.jpg](https://github.com/YaJProgrammist/KryptoLab2/blob/main/Screenshots/q1q2XORcribword.jpg?raw=true)<br>

5) When the result from step 4 is a readable text, we guess the English word and expand our crib search. <br>
-> If the result is not readable text, we try an XOR of the crib word at the next position. <br>
Now we can see the result : <br>
![resultOfWordThe.jpg](https://github.com/YaJProgrammist/KryptoLab2/blob/main/Screenshots/resultOfWordThe.jpg?raw=true)<br>

As we see, in some ocassions it returns combination of readable letters, but the whole word is still hard to recognize. So we should try another word, for example "and " - as we consider, phrases must contain spaces, so we can try enter words with them<br>

The result : <br>
![resultOfWordAnd.jpg](https://github.com/YaJProgrammist/KryptoLab2/blob/main/Screenshots/resultOfWordAnd.jpg?raw=true)<br>
So we've got readable text "if y" on the [0] position of the text (offset equals zero) <br>
We then repeat the process, guessing what “if y” might be when expanded and then XOR that result with the XOR of the cipher-texts. Let's check crib “if you ” - convert it to a hex string, and XOR it with the XOR of the cipher-texts, we’ll get “and ris”.
![resultOfWordIfyou.jpg](https://github.com/YaJProgrammist/KryptoLab2/blob/main/Screenshots/resultOfWordIfyou.jpg?raw=true)<br>
So using this method we can find all other words for our ciphertexts<br>
