Topic-based publish and subsribe

A * can substitute for exactly one word  
A # can substitute for zero or more words

PublishSubscribe do not keep message on the queue , it only forwards directly to the 
subscriber.

RequestResponse is different from SendReceive because SendRecieve sends message targeti ng a 
specify queue while RequestResponse send to the other method via the queue and waits for
it response. Both will keep message on the queue

Keynotes

Publish and Subscribe -> Broadcast -> Broadcast out but messages not persisted on the queue
Request and Response -> RPC -> Client will wait for a response from the reciever
Send and Recieve -> Flexible Routing -> Message routed to queues with a routing key
Topic Based Publish and Subscriber -> Wildcard Routing -> Messages routed to queues using a wildcard based routing key 