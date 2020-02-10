# kube-poc

## Prerequisites

1. A Kubernetes cluster. [Docker for Desktop](https://docs.docker.com/docker-for-windows/#kubernetes) is the easiest, but [Minikube](https://github.com/kubernetes/minikube) is another good option.
2. `kubectl`: [Install kubectl](https://kubernetes.io/docs/tasks/tools/install-kubectl/) or if you have Chocolatey, just `choco install kubernetes-cli`
3. Garden CLI: [Installation Docs](https://docs.garden.io/installation)

## Getting Started

Just run `garden dev` to get up and running. This will set up the cluster, install gloo for routing, and install the app ready to be worked on. Once it's running, just go to [localhost:8080](http://localhost:8080/) to see the result.
